using Shared.Entities.Logs;

namespace API.Services.LogService
{
	public interface ILogService
	{
		Task<ServiceResponse<LogEntry?>> Create(LogEntry request);
		Task<ServiceResponse<List<LogEntry>?>> GetAll();
		Task<ServiceResponse<List<LogEntry>>> GetByLevel(string level);
	}
}
