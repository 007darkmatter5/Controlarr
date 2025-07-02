namespace API.Services.LogService
{
	public class LogService : ILogService
	{
		private readonly DataContext _dataContext;

		public LogService(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public async Task<ServiceResponse<LogEntry?>> Create(LogEntry request)
		{
			var newEntity = new LogEntry
			{
				Level = request.Level,
				Message = request.Message,
				Exception = request.Exception,
				Source = request.Source,
				EventId = request.EventId
			};

			_dataContext.Logs.Add(newEntity);
			await _dataContext.SaveChangesAsync();

			return new ServiceResponse<LogEntry?>
			{
				Data = newEntity,
				Message = "LogEntry created successfully."
			};
		}

		public async Task<ServiceResponse<List<LogEntry>>> GetAll()
		{
			var dbObjects = await _dataContext.Logs
				.ToListAsync();

			var response = new ServiceResponse<List<LogEntry>>
			{
				Data = dbObjects
			};

			response.Message = response.Data.Count == 0 ? "No Logs found." : "Logs found.";

			return response;
		}

		public async Task<ServiceResponse<List<LogEntry>?>> GetByLevel(string level)
		{
			if (!Enum.TryParse<Shared.Entities.Logs.LogLevel>(level, true, out var parsedLevel))
			{
				return new ServiceResponse<List<LogEntry>?>
				{
					Data = null,
					Success = false,
					Message = $"Invalid log level: {level}"
				};
			}

			var dbObjects = await _dataContext.Logs
				.Where(x => x.Level == parsedLevel && !x.IsDeleted)
				.OrderByDescending(x => x.DateCreated)
				.ToListAsync();

			if (dbObjects is null)
			{
				return new ServiceResponse<List<LogEntry>?>
				{
					Data = null,
					Success = false,
					Message = $"No Logs of level {level} found."
				};
			}

			return new ServiceResponse<List<LogEntry>?>
			{
				Data = dbObjects,
				Message = $"Logs with level {level} retrieved successfully."
			};
		}
	}
}
