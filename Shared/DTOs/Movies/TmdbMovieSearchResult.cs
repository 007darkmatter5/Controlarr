using Shared.Entities;

namespace Shared.DTOs.Movies
{
	public class TmdbMovieSearchResult : BaseEntity
	{
		public string Title { get; set; }
		public string Overview { get; set; }
		public string ReleaseDate { get; set; }
		public string PosterPath { get; set; }
		public double VoteAverage { get; set; }
	}
}
