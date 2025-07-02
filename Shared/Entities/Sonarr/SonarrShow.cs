namespace Shared.Entities.Sonarr
{
	public class SonarrShow
	{
		public int id { get; set; }
		public string imdbId { get; set; }
		public string remotePoster { get; set; }
		public string status { get; set; }
		public string title { get; set; }
		public int tvdbId { get; set; }
		public int year { get; set; }
	}
}
