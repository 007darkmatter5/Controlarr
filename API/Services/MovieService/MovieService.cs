namespace API.Services.MovieService
{
	public class MovieService : IMovieService
	{
		private readonly HttpClient _httpClient;
		private readonly string _apiKey;
		private readonly string _baseUrl;

		public MovieService(HttpClient httpClient, IConfiguration configuration)
		{
			_httpClient = httpClient;
			_apiKey = configuration["Tmdb:ApiKey"] ?? throw new ArgumentNullException("TMDB API key is not configured.");
			_baseUrl = configuration["Tmdb:BaseUrl"] ?? "https://api.themoviedb.org/3/";
		}

		public async Task<Movie?> GetMovieByIdAsync(int movieId)
		{
			try
			{
				var response = await _httpClient.GetFromJsonAsync<TmdbResponse>(
					$"{_baseUrl}/movie/{movieId}?api_key={_apiKey}");

				if (response == null) return null;

				return new Movie
				{
					Id = response.Id,
					Title = response.Title,
					Overview = response.Overview,
					ReleaseDate = response.ReleaseDate,
					Genres = response.Genres.Select(g => g.Name).ToList(),
					VoteAverage = response.VoteAverage
				};
			}
			catch (HttpRequestException)
			{
				return null;
			}
		}
	}
}
