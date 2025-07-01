using API.Services.RadarrService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Entities.Radarr;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RadarrController : ControllerBase
	{
		private readonly IRadarrService _radarrService;

		public RadarrController(IRadarrService radarrService)
		{
			_radarrService = radarrService;
		}

		[HttpGet("movies")]
		public async Task<ActionResult<ServiceResponse<List<RadarrMovie>>>> GetAll()
		{
			try
			{
				var movies = await _radarrService.GetAll();

				if (movies == null || !movies.Data.Any())
				{
					return NotFound("No movies found.");
				}

				return Ok(movies);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"An error occurred while fetching movies: {ex.Message}");
			}
		}
	}
}
