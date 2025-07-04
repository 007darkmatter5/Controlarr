﻿namespace Shared.Entities.Movies
{
	public class Movie : BaseEntity
	{
		public string Title { get; set; }
		public string Overview { get; set; }
		public string ReleaseDate { get; set; }
		public string PosterPath { get; set; }
		public double VoteAverage { get; set; }
	}
}
