namespace Shared.DTOs.Node
{
	public record struct InactiveNodeResponse(
		int Id,
		string ApplicationAlias,
		string ParentApplication,
		string BaseUrl,
		string ApiKey,
		bool IsDeleted,
		DateTime DateDeleted
		);
}
