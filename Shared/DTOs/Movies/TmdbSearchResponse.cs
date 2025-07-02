namespace Shared.DTOs.Movies
{
	public class TmdbSearchResponse
	{
		public int Page { get; set; }
		public List<TmdbMovieSearchResult> Results { get; set; }
	}
}
