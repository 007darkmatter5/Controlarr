//using API.Factories.NodeClientFactory;
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
		//private readonly INodeClientFactory _nodeClientFactory;

		//public RadarrController(INodeClientFactory nodeClientFactory)
		//{
		//	_nodeClientFactory = nodeClientFactory;
		//}

		//[HttpGet("movies")]
		//public async Task<ActionResult<IEnumerable<object>>> GetMovies()
		//{
		//	var client = await _nodeClientFactory.CreateClientAsync("Radarr");
		//	var response = await client.GetAsync("/api/v3/movies");
		//	response.EnsureSuccessStatusCode();
		//	var movies = await response.Content.ReadFromJsonAsync<IEnumerable<object>>();
		//	return Ok(movies);
		//}

		//private readonly IRadarrService _radarrService;

		//public RadarrController(IRadarrService radarrService)
		//{
		//	_radarrService = radarrService;
		//}

		//[HttpGet("movies")]
		//public async Task<ActionResult<ServiceResponse<List<RadarrMovie>>>> GetAll()
		//{
		//	try
		//	{
		//		var movies = await _radarrService.GetAll();

		//		if (movies == null || !movies.Data.Any())
		//		{
		//			return NotFound("No movies found.");
		//		}

		//		return Ok(movies);
		//	}
		//	catch (Exception ex)
		//	{
		//		return StatusCode(500, $"An error occurred while fetching movies: {ex.Message}");
		//	}
		//}
	}
}
