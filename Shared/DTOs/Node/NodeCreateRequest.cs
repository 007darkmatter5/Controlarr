namespace Shared.DTOs.Node
{
	public record struct NodeCreateRequest(
		string ApplicationAlias,
		string ParentApplication,
		string BaseUrl,
		string ApiKey
		);
}
