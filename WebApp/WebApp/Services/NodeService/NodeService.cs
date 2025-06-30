using Shared;
using Shared.DTOs.Node;
using Shared.Entities.Nodes;
using System.Net.Http;

namespace WebApp.Services.NodeService
{
	public class NodeService : INodeService
	{
		private readonly HttpClient _httpClient;

		public NodeService(IHttpClientFactory httpClientFactory)
		{
			_httpClient = httpClientFactory.CreateClient("LocalApi"); ;
		}
		public List<Node> ActiveNodes { get; set; }
		public List<Node> InactiveNodes { get; set; }

		public event Action? OnChange;

		public async Task<ServiceResponse<Node>> Create(Node node)
		{
			try
			{
				var response = await _httpClient.PostAsJsonAsync("api/nodes", node);
				var responseContent = await response.Content.ReadFromJsonAsync<ServiceResponse<Node>>();
				if (responseContent != null && responseContent.Success)
				{
					return responseContent;
				}
				else
				{
					return new ServiceResponse<Node>
					{
						Success = false,
						Message = responseContent?.Message ?? "An unknown error occurred."
					};
				}
			}
			catch (Exception ex)
			{
				return new ServiceResponse<Node>
				{
					Success = false,
					Message = $"Exception: {ex.Message}"
				};
			}
			finally
			{
				await GetAllActive();
			}
		}

		public async Task GetAllActive()
		{
			var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Node>>>("api/nodes");
			if (response != null && response.Data != null && response.Success)
				ActiveNodes = response.Data;
		}

		public async Task GetAllInactive()
		{
			var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Node>>>($"api/nodes/inactive");
			if (response != null && response.Data != null && response.Success)
				InactiveNodes = response.Data;
		}

		public async Task<ServiceResponse<Node>> GetById(int id)
		{
			var response = await _httpClient.GetFromJsonAsync<ServiceResponse<Node>>($"api/nodes/{id}");
			return response;
		}

		public async Task<ServiceResponse<NodeVersion>> GetNodeVersion(int id)
		{
			var response = await _httpClient.GetFromJsonAsync<ServiceResponse<NodeVersion>>($"/api/nodes/version/{id}");
			return response;
		}

		public async Task HardDeleteById(int id)
		{
			try
			{
				var response = await _httpClient.DeleteAsync($"/api/nodes/{id}");
				var responseContent = await response.Content.ReadFromJsonAsync<ServiceResponse<Node>>();
				if (responseContent != null && responseContent.Success)
				{
					// Handle success (if ndeeded)
				}
				else
				{
					var errorMessage = responseContent.Message ?? "An unknown error occurred.";
					Console.WriteLine($"Error: {errorMessage}");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Exception: {ex.Message}");
			}
			finally
			{
				await GetAllActive();
			}
		}

		public async Task RestoreById(Node node)
		{
			try
			{
				var response = await _httpClient.PutAsJsonAsync($"api/nodes/restore/{node.Id}", node);
				var responseContent = await response.Content.ReadFromJsonAsync<ServiceResponse<Node>>();
				if (responseContent != null && responseContent.Success)
				{
					// Handle success (if needed)
				}
				else
				{
					var errorMessage = responseContent.Message ?? "An unknown error occurred.";
					Console.WriteLine($"Error: {errorMessage}");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Exception: {ex.Message}");
			}
			finally
			{
				await GetAllActive();
			}
		}

		public async Task SoftDeleteById(int id)
		{
			try
			{
				var response = await _httpClient.PutAsJsonAsync($"api/nodes/softdelete/{id}", id);
				var responseContent = await response.Content.ReadFromJsonAsync<ServiceResponse<Node>>();
				if (responseContent != null && responseContent.Success)
				{
					// Handle success (if needed)
				}
				else
				{
					var errorMessage = responseContent.Message ?? "An unknown error occurred.";
					Console.WriteLine($"Error: {errorMessage}");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Exception: {ex.Message}");
			}
			finally
			{
				await GetAllActive();
			}
		}

		public async Task<ServiceResponse<Node>> Update(Node node)
		{
			try
			{
				var response = await _httpClient.PutAsJsonAsync($"api/nodes", node);
				var responseContent = await response.Content.ReadFromJsonAsync<ServiceResponse<Node>>();

				if (responseContent != null && responseContent.Success)
				{
					return responseContent;
				}
				else
				{
					return new ServiceResponse<Node>
					{
						Success = false,
						Message = responseContent?.Message ?? "An unknown error occurred."
					};
				}
			}
			catch (Exception ex)
			{
				return new ServiceResponse<Node>
				{
					Success = false,
					Message = $"Exception: {ex.Message}"
				};
			}
			finally
			{
				await GetAllActive();
			}
		}
	}
}
