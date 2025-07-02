namespace Shared.Entities.TMDB
{
	public class TmdbMovieSearchResult
	{
		public bool adult { get; set; }
		public string? backdrop_path { get; set; }
		public List<int> genre_ids { get; set; } = new();
		public int id { get; set; }
		public string original_language { get; set; } = string.Empty;
		public string original_title { get; set; } = string.Empty;
		public string overview { get; set; } = string.Empty;
		public double popularity { get; set; }
		public string? poster_path { get; set; }
		public string? release_date { get; set; }
		public string title { get; set; } = string.Empty;
		public bool video { get; set; }
		public double vote_average { get; set; }
		public int vote_count { get; set; }
	}
}
