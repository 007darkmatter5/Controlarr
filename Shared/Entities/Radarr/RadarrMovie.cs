namespace Shared.Entities.Radarr
{
	public class RadarrMovie
	{
		public int id { get; set; }
		public string imdbId { get; set; }
		public string remotePoster { get; set; }
		public string status { get; set; }
		public string title { get; set; }
		public int tmdbId { get; set; }
		public int year { get; set; }
	}
}
