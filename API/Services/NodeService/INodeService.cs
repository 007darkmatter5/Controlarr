using Shared.DTOs.Node;

namespace API.Services.NodeService
{
	public interface INodeService
	{
		Task<ServiceResponse<NodeResponse?>> Create(NodeCreateRequest request);
		Task<ServiceResponse<List<NodeResponse>>> GetAllActive();
		Task<ServiceResponse<List<InactiveNodeResponse>>> GetAllInactive();
		Task<ServiceResponse<NodeResponse?>> GetById(int id);
		Task<ServiceResponse<NodeResponse?>> GetByParentApplication(string parentApplicationName);
		Task<ServiceResponse<NodeResponse?>> GetVersion(int id);
		Task<ServiceResponse<List<NodeResponse>?>> HardDeleteById(int id);
		Task<ServiceResponse<NodeResponse?>> RestoreById(int id);
		Task<ServiceResponse<NodeResponse?>> SoftDeleteById(int id);
		Task<ServiceResponse<NodeResponse?>> Update(NodeUpdateRequest request);
	}
}
