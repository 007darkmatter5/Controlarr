namespace API.Factories.NodeClientFactory
{
	public interface INodeClientFactory
	{
		Task<HttpClient?> CreateClientAsync(string applicationAlias);
	}
}
