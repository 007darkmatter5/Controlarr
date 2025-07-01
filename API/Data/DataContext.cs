using Microsoft.EntityFrameworkCore;
using Shared.Entities.Logs;
using Shared.Entities.Nodes;

namespace API.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options) { }

		public DbSet<LogEntry> Logs { get; set; }
		public DbSet<Node> Nodes { get; set; }
	}
}
