using Shared.Entities.TMDB;

namespace API.Services.TmdbService
{
	public interface ITmdbService
	{
		Task<TmdbMovieSearchResponse?> SearchMovieAsync(
			string query,
			bool include_adult = false,
			string language = "en_US",
			string primary_release_year = "",
			int page = 1,
			string region = "",
			string year = ""
		);
	}
}
