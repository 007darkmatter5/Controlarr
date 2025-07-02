namespace WebApp.Services.NodeService
{
	public interface INodeService
	{
		//event Action? OnChange;
		List<Node> ActiveNodes { get; set; }
		List<Node> InactiveNodes { get; set; }
		Task<ServiceResponse<Node>> Create(Node node);
		Task GetAllActive();
		Task GetAllInactive();
		Task<ServiceResponse<Node>> GetById(int id);
		Task<ServiceResponse<NodeVersion>> GetNodeVersion(int id);
		Task HardDeleteById(int id);
		Task RestoreById(Node node);
		Task SoftDeleteById(int id);
		Task<ServiceResponse<Node>> Update(Node node);
	}
}
