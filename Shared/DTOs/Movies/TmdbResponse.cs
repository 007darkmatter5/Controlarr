using System.Text.Json.Serialization;

namespace Shared.DTOs.Movies
{
	public class TmdbResponse
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Overview {  get; set; } = string.Empty;
		[JsonPropertyName("release_date")]
		public string ReleaseDate { get; set; } = string.Empty;
		[JsonPropertyName("vote_average")]
		public double VoteAverage {  get; set; }
		public List<Genre> Genres { get; set; } = new List<Genre>();
	}

	public class Genre
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
	}
}
