using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Shared.Entities.Radarr
{
	public class rm
	{
		public class Movie
		{
			public int Id { get; set; }
			public string Title { get; set; }
			public string OriginalTitle { get; set; }
			public Language OriginalLanguage { get; set; }
			public List<AlternateTitle> AlternateTitles { get; set; }
			public int SecondaryYear { get; set; }
			public int SecondaryYearSourceId { get; set; }
			public string SortTitle { get; set; }
			public long SizeOnDisk { get; set; }
			public string Status { get; set; }
			public string Overview { get; set; }
			public DateTime InCinemas { get; set; }
			public DateTime PhysicalRelease { get; set; }
			public DateTime DigitalRelease { get; set; }
			public DateTime ReleaseDate { get; set; }
			public string PhysicalReleaseNote { get; set; }
			public List<Image> Images { get; set; }
			public string Website { get; set; }
			public string RemotePoster { get; set; }
			public int Year { get; set; }
			public string YouTubeTrailerId { get; set; }
			public string Studio { get; set; }
			public string Path { get; set; }
			public int QualityProfileId { get; set; }
			public bool HasFile { get; set; }
			public int MovieFileId { get; set; }
			public bool Monitored { get; set; }
			public string MinimumAvailability { get; set; }
			public bool IsAvailable { get; set; }
			public string FolderName { get; set; }
			public int Runtime { get; set; }
			public string CleanTitle { get; set; }
			public string ImdbId { get; set; }
			public int TmdbId { get; set; }
			public string TitleSlug { get; set; }
			public string RootFolderPath { get; set; }
			public string Folder { get; set; }
			public string Certification { get; set; }
			public List<string> Genres { get; set; }
			public List<string> Keywords { get; set; }
			public List<int> Tags { get; set; }
			public DateTime Added { get; set; }
			public AddOptions AddOptions { get; set; }
			public Ratings Ratings { get; set; }
			public MovieFile MovieFile { get; set; }
		}

		public class Language
		{
			public int Id { get; set; }
			public string Name { get; set; }
		}

		public class AlternateTitle
		{
			public int Id { get; set; }
			public string SourceType { get; set; }
			public int MovieMetadataId { get; set; }
			public string Title { get; set; }
			public string CleanTitle { get; set; }
		}

		public class Image
		{
			public string CoverType { get; set; }
			public string Url { get; set; }
			public string RemoteUrl { get; set; }
		}

		public class AddOptions
		{
			public bool IgnoreEpisodesWithFiles { get; set; }
			public bool IgnoreEpisodesWithoutFiles { get; set; }
			public string Monitor { get; set; }
			public bool SearchForMovie { get; set; }
			public string AddMethod { get; set; }
		}

		public class Ratings
		{
			public RatingDetail Imdb { get; set; }
			public RatingDetail Tmdb { get; set; }
			public RatingDetail Metacritic { get; set; }
			public RatingDetail RottenTomatoes { get; set; }
			public RatingDetail Trakt { get; set; }
		}

		public class RatingDetail
		{
			public int Votes { get; set; }
			public double Value { get; set; }
			public string Type { get; set; }
		}

		public class MovieFile
		{
			public int Id { get; set; }
			public int MovieId { get; set; }
			public string RelativePath { get; set; }
			public string Path { get; set; }
			public long Size { get; set; }
			public DateTime DateAdded { get; set; }
			public string SceneName { get; set; }
			public string ReleaseGroup { get; set; }
			public string Edition { get; set; }
			public List<Language> Languages { get; set; }
			public QualityWrapper Quality { get; set; }
			public List<CustomFormat> CustomFormats { get; set; }
		}

		public class QualityWrapper
		{
			public QualityDetail Quality { get; set; }
			public QualityRevision Revision { get; set; }
		}

		public class QualityDetail
		{
			public int Id { get; set; }
			public string Name { get; set; }
			public string Source { get; set; }
			public int Resolution { get; set; }
			public string Modifier { get; set; }
		}

		public class QualityRevision
		{
			public int Version { get; set; }
			public int Real { get; set; }
			public bool IsRepack { get; set; }
		}

		public class CustomFormat
		{
			public int Id { get; set; }
			public string Name { get; set; }
			public bool IncludeCustomFormatWhenRenaming { get; set; }
			public List<Specification> Specifications { get; set; }
		}

		public class Specification
		{
			public int Id { get; set; }
			public string Name { get; set; }
		}
	}
}
