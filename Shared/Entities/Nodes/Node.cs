using System.ComponentModel.DataAnnotations;

namespace Shared.Entities.Nodes
{
	public class Node : BaseEntity
	{
		[Required]
		public string ApplicationAlias { get; set; }
		[Required]
		public string ParentApplication { get; set; }
		public string BaseUrl { get; set; } = string.Empty;
		public string ApiKey { get; set; } = string.Empty;
	}
}
