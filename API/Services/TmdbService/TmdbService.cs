
using Shared.Entities.TMDB;
using System.Text.Json;

namespace API.Services.TmdbService
{
	public class TmdbService : ITmdbService
	{
		private readonly HttpClient _httpClient;
		private readonly IConfiguration _config;

		public TmdbService(HttpClient httpClient, IConfiguration config)
		{
			_httpClient = httpClient;
			_config = config;
		}

		public async Task<TmdbMovieSearchResponse?> SearchMovieAsync(string query, bool include_adult = false, string language = "en_US", string primary_release_year = "", int page = 1, string region = "", string year = "")
		{
			var apiKey = _config["TMDB:ApiKey"];
			var baseUrl = _config["TMDB:BaseUrl"];

			if (string.IsNullOrWhiteSpace(apiKey))
				throw new InvalidOperationException("TMDB API Key not configured.");

			var url = $"{baseUrl}search/movie?api_key={apiKey}&query={Uri.EscapeDataString(query)}";

			var response = await _httpClient.GetAsync(url);
			response.EnsureSuccessStatusCode();

			var json = await response.Content.ReadAsStringAsync();
			var tmdbResponse = JsonSerializer.Deserialize<TmdbMovieSearchResponse>(json, new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			});

			return tmdbResponse;
		}
	}
}
