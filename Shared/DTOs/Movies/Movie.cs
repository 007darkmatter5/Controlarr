namespace Shared.DTOs.Movies
{
	public class Movie
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Overview { get; set; } = string.Empty;
		public string ReleaseDate { get; set; } = string.Empty;
		public List<string> Genres { get; set; } = new List<string>();
		public double VoteAverage { get; set; }
	}
}
