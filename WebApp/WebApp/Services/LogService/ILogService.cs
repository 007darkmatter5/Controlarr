namespace WebApp.Services.LogService
{
	public interface ILogService
	{
		List<LogEntry> Logs { get; set; }
		Task<ServiceResponse<LogEntry>> Create(LogEntry entry);
		Task GetAll();
		Task GetAllByLevel(string level);
	}
}
