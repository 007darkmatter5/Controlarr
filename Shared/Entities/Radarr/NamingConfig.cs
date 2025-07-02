namespace Shared.Entities.Radarr
{
	public class NamingConfig
	{
		public int id { get; set; }
		public bool renameMovies { get; set; }
		public bool replaceIllegalCharacters {  get; set; }
		public string colonReplacementFormat { get; set; }
		public string standardMovieFormat { get; set; }
		public string movieFolderFormat { get; set; }
	}
}
