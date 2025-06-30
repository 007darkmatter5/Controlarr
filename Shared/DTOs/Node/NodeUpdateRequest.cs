namespace Shared.DTOs.Node
{
	public record struct NodeUpdateRequest(
		int Id,
		string ApplicationAlias,
		string ParentApplication,
		string BaseUrl,
		string ApiKey,
		bool IsDeleted
		);
}
