namespace WebApp.Services.LogService
{
	public class LogService : ILogService
	{
		private readonly HttpClient _httpClient;

		public LogService(IHttpClientFactory httpClientFactory)
		{
			_httpClient = httpClientFactory.CreateClient("LocalApi");
		}

		public List<LogEntry> Logs { get; set; }

		public async Task<ServiceResponse<LogEntry>> Create(LogEntry entry)
		{
			try
			{
				var response = await _httpClient.PostAsJsonAsync("api/logs", entry);
				var responseContent = await response.Content.ReadFromJsonAsync<ServiceResponse<LogEntry>>();
				if (responseContent != null && responseContent.Success)
				{
					return responseContent;
				}
				else
				{
					return new ServiceResponse<LogEntry>
					{
						Success = false,
						Message = responseContent?.Message ?? "An unknown error occurred."
					};
				}
			}
			catch (Exception ex)
			{
				return new ServiceResponse<LogEntry>
				{
					Success = false,
					Message = $"Exception: {ex.Message}"
				};
			}
			finally
			{
				await GetAll();
			}
		}

		public async Task GetAll()
		{
			var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<LogEntry>>>("api/logs");
			if (response != null && response.Data != null && response.Success)
				Logs = response.Data;
		}

		public async Task GetAllByLevel(string level)
		{
			var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<LogEntry>>>($"/api/logs/{level}");
			if (response != null && response.Data != null && response.Success)
				Logs = response.Data;
		}
	}
}
