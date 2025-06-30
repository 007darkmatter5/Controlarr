namespace Shared.Entities
{
	public class BaseEntity
	{
		public int Id { get; set; }
		public bool IsDeleted { get; set; } = false;
		public DateTime DateCreated { get; set; } = DateTime.Now;
		public DateTime? DateUpdated { get; set; }
		public DateTime? DateDeleted { get; set; }
	}
}
