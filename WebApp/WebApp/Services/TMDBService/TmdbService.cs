using System.Text.Json;

namespace WebApp.Services.TmdbService
{
	public class TmdbService : ITmdbService
	{
		private readonly HttpClient _httpClient;

		public TmdbService(IHttpClientFactory httpClientFactory)
		{
			_httpClient = httpClientFactory.CreateClient("LocalApi");
		}

		public async Task<TmdbMovieSearchResponse?> SearchMovieAsync(string query)
		{
			if (string.IsNullOrWhiteSpace(query)) return null;

			var response = await _httpClient.GetFromJsonAsync<TmdbMovieSearchResponse>(
				$"api/movies/search?query={Uri.EscapeDataString(query)}");

			return response;
		}
	}
}
