using API.Services.TmdbService;
using Microsoft.AspNetCore.Mvc;
using Shared.Entities.TMDB;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MoviesController : ControllerBase
	{
		private readonly IMovieService _movieService;
		private readonly ITmdbService _tmdbService;

		public MoviesController(IMovieService movieService, ITmdbService tmdbService)
		{
			_movieService = movieService;
			_tmdbService = tmdbService;
		}

		[HttpGet("{movieId}")]
		public async Task<IActionResult> GetMovie(int movieId)
		{
			var movie = await _movieService.GetMovieByIdAsync(movieId);
			return movie != null ? Ok(movie) : NotFound();
		}

		[HttpGet("search")]
		public async Task<ActionResult<TmdbMovieSearchResponse>> SearchMovies(
			[FromQuery] string query,
			[FromQuery] bool include_adult = false,
			[FromQuery] string language = "en_US",
			[FromQuery] string primary_release_year = "",
			[FromQuery] int page = 1,
			[FromQuery] string region = "",
			[FromQuery] string year = ""
		)
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return BadRequest("Search query is required.");
			}

			try
			{
				var result = await _tmdbService.SearchMovieAsync(query, include_adult, language, primary_release_year, page, region, year);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"An error occurred while searching TMDB: {ex.Message}");
			}
		}
	}
}
