namespace API.Services.SonarrService
{
	public class SonarrService : ISonarrService
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly INodeService _nodeService;
		private Node? _nodeConfig;

		public SonarrService(IHttpClientFactory httpClientFactory, INodeService nodeService)
		{
			_httpClientFactory = httpClientFactory;
			_nodeService = nodeService;
		}

		//private async Task EnsureConfiguredAsync()
		//{
		//	if (_nodeConfig == null)
		//	{
		//		var response = await _nodeService.GetByParentApplication("Sonarr");
		//		if (!response.Success || response.Data == null)
		//		{
		//			throw new InvalidOperationException($"Failed to retrieve node configuration: {response.Message}");
		//		}
		//		_nodeConfig = response.Data;
		//	}
		//}

		public Task<ServiceResponse<List<SonarrShow>>> GetAll()
		{
			throw new NotImplementedException();
		}

		public Task<ServiceResponse<SonarrShow?>> GetById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<ServiceResponse<SonarrSystemStatus>> GetStatus()
		{
			throw new NotImplementedException();
		}

		public Task<ServiceResponse<List<SonarrShow>>> MovieLookup(string term)
		{
			throw new NotImplementedException();
		}

		public Task<ServiceResponse<List<SonarrShow>>> MovieLookupImdb(string imdbid)
		{
			throw new NotImplementedException();
		}

		public Task<ServiceResponse<List<SonarrShow>>> MovieLookupTmdb(string tmdbid)
		{
			throw new NotImplementedException();
		}

		public Task<ServiceResponse<List<SonarrShow>>> WantedMissing()
		{
			throw new NotImplementedException();
		}
	}
}
