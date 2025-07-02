namespace WebApp.Services.TmdbService
{
	public interface ITmdbService
	{
		Task<TmdbMovieSearchResponse?> SearchMovieAsync(string query);
	}
}
