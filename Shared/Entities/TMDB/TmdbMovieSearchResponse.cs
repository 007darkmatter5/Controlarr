namespace Shared.Entities.TMDB
{
	public class TmdbMovieSearchResponse
	{
		public int page { get; set; }
		public List<TmdbMovieSearchResult> results { get; set; }
		public int total_pages { get; set; }
		public int total_results { get; set; }
	}
}
