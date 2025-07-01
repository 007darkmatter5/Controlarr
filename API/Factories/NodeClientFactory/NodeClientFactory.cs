
using API.Services.NodeService;

namespace API.Factories.NodeClientFactory
{
	public class NodeClientFactory : INodeClientFactory
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly INodeService _nodeService;

		public NodeClientFactory(IHttpClientFactory httpClientFactory, INodeService nodeService)
		{
			_httpClientFactory = httpClientFactory;
			_nodeService = nodeService;
		}

		public async Task<HttpClient> CreateClientAsync(string applicationAlias)
		{
			var nodeResult = await _nodeService.GetByApplicationAlias(applicationAlias);
			if (!nodeResult.Success || nodeResult.Data is null)
			{
				throw new Exception($"Node config for '{applicationAlias}' not found.");
			}

			var client = _httpClientFactory.CreateClient();
			client.BaseAddress = new Uri(nodeResult.Data.BaseUrl);
			client.DefaultRequestHeaders.Clear();
			client.DefaultRequestHeaders.Add("X-Api-Key", nodeResult.Data.ApiKey);

			return client;
		}
	}
}
