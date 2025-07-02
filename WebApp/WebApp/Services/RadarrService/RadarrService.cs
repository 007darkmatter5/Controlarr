namespace WebApp.Services.RadarrService
{
	public class RadarrService : IRadarrService
	{
		private readonly HttpClient _httpClient;

		public RadarrService(IHttpClientFactory httpClientFactory)
		{
			_httpClient = httpClientFactory.CreateClient("LocalApi");
		}

		public List<RadarrMovie> Movies { get; set; }
		public List<RadarrMovie> LookupResults { get; set; }

		//public event Action? OnChange;

		public async Task GetAll()
		{
			var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<RadarrMovie>>>("api/radarr/movies");
			if (response != null && response.Data != null && response.Success)
				Movies = response.Data;
		}

		public async Task<ServiceResponse<RadarrMovie>> GetById(int id)
		{
			var response = await _httpClient.GetFromJsonAsync<ServiceResponse<RadarrMovie>>($"api/radarr/movies/{id}");
			return response;
		}

		public async Task<ServiceResponse<List<RadarrMovie>>> GetMovieLookup(string term)
		{
			var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<RadarrMovie>>>($"api/radarr/movie/lookup/{term}");
			return response ?? new ServiceResponse<List<RadarrMovie>> {  Success = false, Message = "No response from server." };
			
			//if (response != null && response.Data != null && response.Success)
			//	LookupResults = response.Data;
		}

		public async Task<ServiceResponse<RadarrMovie>> GetMovieLookupImdb(string imdbid)
		{
			var response = await _httpClient.GetFromJsonAsync<ServiceResponse<RadarrMovie>>($"api/radarr/movie/lookup/imdb/{imdbid}");
			return response ?? new ServiceResponse<RadarrMovie> { Success = false, Message = "No response from server." };
		}

		public async Task<ServiceResponse<RadarrMovie>> GetMovieLookupTmdb(string tmdbid)
		{
			var response = await _httpClient.GetFromJsonAsync<ServiceResponse<RadarrMovie>>($"api/radarr/movie/lookup/tmdb/{tmdbid}");
			return response ?? new ServiceResponse<RadarrMovie> { Success = false, Message = "No response from server." };
		}
	}
}
