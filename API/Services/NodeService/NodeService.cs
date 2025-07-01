using API.Data;
using Shared.DTOs.Node;
using Shared.Entities.Lidarr;
using Shared.Entities.Nodes;
using Shared.Entities.Radarr;
using Shared.Entities.Readarr;
using Shared.Entities.Sonarr;
using System.Globalization;

namespace API.Services.NodeService
{
	public class NodeService : INodeService
	{
		private readonly DataContext _dataContext;

		public NodeService(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public async Task<ServiceResponse<NodeResponse?>> Create(NodeCreateRequest request)
		{
			TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
			request.ApplicationAlias = textInfo.ToTitleCase(request.ApplicationAlias);

			var newEntity = new Node
			{
				ApiKey = request.ApiKey,
				ApplicationAlias = request.ApplicationAlias,
				BaseUrl = request.BaseUrl,
				ParentApplication = request.ParentApplication
			};

			_dataContext.Nodes.Add(newEntity);
			await _dataContext.SaveChangesAsync();

			var createdObjectResponse = request.Adapt<NodeResponse>();

			return new ServiceResponse<NodeResponse?>
			{
				Data = createdObjectResponse,
				Message = "Node created successfully."
			};
		}

		public async Task<ServiceResponse<List<NodeResponse>>> GetAllActive()
		{
			var dbObjects = await _dataContext.Nodes
				.Where(x => !x.IsDeleted)
				.ToListAsync();
			var dbObjectResponses = dbObjects.Adapt<List<NodeResponse>>();

			var response = new ServiceResponse<List<NodeResponse>>
			{
				Data = dbObjectResponses
			};

			response.Message = response.Data.Count == 0 ? "No Nodes found." : "Nodes found.";

			return response;
		}

		public async Task<ServiceResponse<List<InactiveNodeResponse>>> GetAllInactive()
		{
			var dbObjects = await _dataContext.Nodes
				.Where(x => x.IsDeleted)
				.ToListAsync();

			var dbObjectResponses = dbObjects.Adapt<List<InactiveNodeResponse>>();

			var response = new ServiceResponse<List<InactiveNodeResponse>>
			{
				Data = dbObjectResponses
			};

			response.Message = response.Data.Count == 0 ? "No Nodes found." : "Nodes found.";

			return response;
		}

		public async Task<ServiceResponse<NodeResponse?>> GetByApplicationAlias(string applicationAlias)
		{
			var dbObject = await _dataContext.Nodes
				.Where(x => x.ApplicationAlias.ToLower() ==  applicationAlias.ToLower() && !x.IsDeleted)
				.FirstOrDefaultAsync();

			if (dbObject == null)
			{
				return new ServiceResponse<NodeResponse?>
				{
					Data = null,
					Success = false,
					Message = $"No active node found with ApplicationAlias = '{applicationAlias}'."
				};
			}

			var dbObjectResponse = dbObject.Adapt<NodeResponse>();

			return new ServiceResponse<NodeResponse?>
			{
				Data = dbObjectResponse,
				Message = "Node found."
			};
		}

		public async Task<ServiceResponse<NodeResponse?>> GetById(int id)
		{
			var dbObject = await _dataContext.Nodes
				.Where(x => x.Id == id)
				.FirstOrDefaultAsync();

			if (dbObject == null)
			{
				return new ServiceResponse<NodeResponse?>
				{
					Data = null,
					Message = "Node not found.",
					Success = false
				};
			}

			var dbObjectResponse = dbObject?.Adapt<NodeResponse>();

			return new ServiceResponse<NodeResponse?>
			{
				Data = dbObjectResponse,
				Message = "Node found."
			};
		}

		public async Task<ServiceResponse<NodeResponse?>> GetByParentApplication(string parentApplicationName)
		{
			var dbObject = await _dataContext.Nodes
				.Where(x => x.ParentApplication.ToLower() == parentApplicationName.ToLower() && !x.IsDeleted)
				.FirstOrDefaultAsync();

			if (dbObject == null)
			{
				return new ServiceResponse<NodeResponse?>
				{
					Data = null,
					Success = false,
					Message = $"No active node found with ParentApplication = '{parentApplicationName}'."
				};
			}

			var response = dbObject.Adapt<NodeResponse>();

			return new ServiceResponse<NodeResponse?>
			{
				Data = response,
				Message = "Node found."
			};
		}

		public async Task<ServiceResponse<NodeResponse?>> GetVersion(int id)
		{
			var dbObject = await _dataContext.Nodes
				.Where(x => x.Id == id)
				.FirstOrDefaultAsync();

			if (dbObject == null)
			{
				return new ServiceResponse<NodeResponse?>
				{
					Data = null,
					Message = "Node not found.",
					Success = false
				};
			}

			var dbObjectResponse = dbObject.Adapt<NodeResponse>();
			string message = "Node found.";
			NodeResponse? updatedResponse = dbObjectResponse;

			// Check ParentApplication and fetch version
			if (dbObjectResponse.ParentApplication == "Lidarr")
			{
				try
				{
					using var httpClient = new HttpClient();
					httpClient.DefaultRequestHeaders.Add("X-Api-Key", dbObjectResponse.ApiKey);

					var response = await httpClient.GetAsync($"{dbObjectResponse.BaseUrl}/api/v3/system/status");
					response.EnsureSuccessStatusCode();

					var status = await response.Content.ReadFromJsonAsync<LidarrSystemStatus>();
					string version = status?.Version ?? "Unknown";
					message = $"Node found. Version {version}";
					updatedResponse = dbObjectResponse with { Version = version };
				}
				catch (Exception ex)
				{
					message = $"Node found, but failed to fetch Lidarr version: {ex.Message}";
					updatedResponse = dbObjectResponse with { Version = "Unknown" };
				}
			}
			if (dbObjectResponse.ParentApplication == "Radarr")
			{
				try
				{
					using var httpClient = new HttpClient();
					httpClient.DefaultRequestHeaders.Add("X-Api-Key", dbObjectResponse.ApiKey);

					var response = await httpClient.GetAsync($"{dbObjectResponse.BaseUrl}/api/v3/system/status");
					response.EnsureSuccessStatusCode();

					var status = await response.Content.ReadFromJsonAsync<RadarrSystemStatus>();
					string version = status?.Version ?? "Unknown";
					message = $"Node found. Version {version}";
					updatedResponse = dbObjectResponse with { Version = version };
				}
				catch (Exception ex)
				{
					message = $"Node found, but failed to fetch Radarr version: {ex.Message}";
					updatedResponse = dbObjectResponse with { Version = "Unknown" };
				}
			}
			if (dbObjectResponse.ParentApplication == "Readarr")
			{
				try
				{
					using var httpClient = new HttpClient();
					httpClient.DefaultRequestHeaders.Add("X-Api-Key", dbObjectResponse.ApiKey);

					var response = await httpClient.GetAsync($"{dbObjectResponse.BaseUrl}/api/v3/system/status");
					response.EnsureSuccessStatusCode();

					var status = await response.Content.ReadFromJsonAsync<ReadarrSystemStatus>();
					string version = status?.Version ?? "Unknown";
					message = $"Node found. Version {version}";
					updatedResponse = dbObjectResponse with { Version = version };
				}
				catch (Exception ex)
				{
					message = $"Node found, but failed to fetch Readarr version: {ex.Message}";
					updatedResponse = dbObjectResponse with { Version = "Unknown" };
				}
			}
			if (dbObjectResponse.ParentApplication == "Sonarr")
			{
				try
				{
					using var httpClient = new HttpClient();
					httpClient.DefaultRequestHeaders.Add("X-Api-Key", dbObjectResponse.ApiKey);

					var response = await httpClient.GetAsync($"{dbObjectResponse.BaseUrl}/api/v3/system/status");
					response.EnsureSuccessStatusCode();

					var status = await response.Content.ReadFromJsonAsync<SonarrSystemStatus>();
					string version = status?.Version ?? "Unknown";
					message = $"Node found. Version {version}";
					updatedResponse = dbObjectResponse with { Version = version };
				}
				catch (Exception ex)
				{
					message = $"Node found, but failed to fetch Sonarr version: {ex.Message}";
					updatedResponse = dbObjectResponse with { Version = "Unknown" };
				}
			}

			return new ServiceResponse<NodeResponse?>
			{
				Data = updatedResponse,
				Message = message,
				Success = true
			};
		}

		public async Task<ServiceResponse<List<NodeResponse>?>> HardDeleteById(int id)
		{
			var dbObject = await _dataContext.Nodes.FindAsync(id);
			if (dbObject == null)
			{
				return null;
			}

			_dataContext.Nodes.Remove(dbObject);
			await _dataContext.SaveChangesAsync();

			var dbObjects = await _dataContext.Nodes.ToListAsync();
			var dbObjectResponses = dbObjects.Adapt<List<NodeResponse>>();

			var response = new ServiceResponse<List<NodeResponse>>
			{
				Data = dbObjectResponses
			};

			if (response.Data.Count == 0)
			{
				response.Message = "Node not found.";
			}
			else
			{
				response.Message = "Node found.";
			}

			return response;
		}

		public async Task<ServiceResponse<NodeResponse?>> RestoreById(int id)
		{
			var dbObject = await _dataContext.Nodes.FindAsync(id);
			if (dbObject == null)
			{
				return null;
			}

			dbObject.IsDeleted = false;

			await _dataContext.SaveChangesAsync();

			var updatedDbObjectResponse = dbObject.Adapt<NodeResponse>();

			return new ServiceResponse<NodeResponse?>
			{
				Data = updatedDbObjectResponse,
				Message = "Node recovered."
			};
		}

		public async Task<ServiceResponse<NodeResponse?>> SoftDeleteById(int id)
		{
			var dbObject = await _dataContext.Nodes.FindAsync(id);
			if (dbObject == null)
			{
				return null;
			}

			dbObject.IsDeleted = true;
			dbObject.DateDeleted = DateTime.Now;

			await _dataContext.SaveChangesAsync();

			var updatedDbObjectResponse = dbObject.Adapt<NodeResponse>();

			return new ServiceResponse<NodeResponse?>
			{
				Data = updatedDbObjectResponse,
				Message = "Node set inactive."
			};
		}

		public async Task<ServiceResponse<NodeResponse?>> Update(NodeUpdateRequest request)
		{
			var dbObject = await _dataContext.Nodes.FindAsync(request.Id);
			if (dbObject == null)
			{
				return null;
			}

			TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
			dbObject.ApplicationAlias = textInfo.ToTitleCase(request.ApplicationAlias);
			dbObject.ApiKey = request.ApiKey;
			dbObject.BaseUrl = request.BaseUrl;
			dbObject.ParentApplication = request.ParentApplication;
			dbObject.DateUpdated = DateTime.Now;

			await _dataContext.SaveChangesAsync();

			var updatedDbObjectResponse = dbObject.Adapt<NodeResponse>();

			return new ServiceResponse<NodeResponse?>
			{
				Data = updatedDbObjectResponse,
				Message = "Node updated."
			};
		}
	}
}
