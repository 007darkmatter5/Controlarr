namespace Shared.DTOs.Node
{
	public record struct NodeResponse(
		int Id,
		string ApplicationAlias,
		string ParentApplication,
		string BaseUrl,
		string ApiKey,
		bool IsDeleted,
		string? Version = null
		);
}
