using API.Factories.NodeClientFactory;
using API.Services.NodeService;
using Shared.Entities.Radarr;

namespace API.Services.RadarrService
{
	public class RadarrService : IRadarrService
	{
		private readonly INodeClientFactory _nodeClientFactory;

		//private readonly HttpClient _httpClient;

		//public RadarrService(HttpClient httpClient, INodeService nodeService)
		//{
		//	_httpClient = httpClient;

		//	var nodeTask = nodeService.GetByParentApplication("Radarr");
		//	nodeTask.Wait();
		//	var nodeResult = nodeTask.Result;

		//	if (nodeResult.Success && nodeResult.Data is not null)
		//	{
		//		_httpClient.BaseAddress = new Uri(nodeResult.Data.BaseUrl);
		//		_httpClient.DefaultRequestHeaders.Clear();
		//		_httpClient.DefaultRequestHeaders.Add("X-Api-Key", nodeResult.Data.ApiKey);
		//	}
		//	else
		//	{
		//		throw new Exception("Radarr node configuration not found or invalid.");
		//	}
		//}

		public RadarrService(INodeClientFactory nodeClientFactory)
		{
			_nodeClientFactory = nodeClientFactory;
		}

		public async Task<ServiceResponse<List<RadarrMovie>>> GetAll()
		{
			var client = _nodeClientFactory.CreateClientAsync("Radarr");

			var response = await client.GetAsync("/api/v3/movie");
			response.EnsureSuccessStatusCode();

			var movies = await response.Content.ReadFromJsonAsync<List<RadarrMovie>>();
			return movies ?? new List<RadarrMovie>();
		}

		public Task<ServiceResponse<RadarrMovie?>> GetById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<ServiceResponse<RadarrSystemStatus>> GetStatus()
		{
			throw new NotImplementedException();
		}

		public Task<ServiceResponse<List<RadarrMovie>>> MovieLookup(string term)
		{
			throw new NotImplementedException();
		}

		public Task<ServiceResponse<List<RadarrMovie>>> MovieLookupImdb(string imdbid)
		{
			throw new NotImplementedException();
		}

		public Task<ServiceResponse<List<RadarrMovie>>> MovieLookupTmdb(string tmdbid)
		{
			throw new NotImplementedException();
		}

		public Task<ServiceResponse<List<RadarrMovie>>> WantedMissing()
		{
			throw new NotImplementedException();
		}
	}
}
