using Microsoft.AspNetCore.Mvc;

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
			var result = await _radarrService.GetAll();
			if (!result.Success)
			{
				return BadRequest(result);
			}

			return Ok(result);
		}

		[HttpGet("status")]
		public async Task<ActionResult<ServiceResponse<RadarrSystemStatus>>> GetStatus()
		{
			var result = await _radarrService.GetStatus();
			if (!result.Success)
			{
				return BadRequest(result);
			}
			return Ok(result);
		}

		[HttpGet("movies/{id}")]
		public async Task<ActionResult<RadarrMovie>> GetById(int id)
		{
			var result = await _radarrService.GetById(id);
			return Ok(result);
		}

		[HttpGet("movie/lookup/{term}")]
		public async Task<ActionResult<ServiceResponse<List<RadarrMovie>>>> GetMovieLookup(string term)
		{
			var result = await _radarrService.GetMovieLookup(term);
			return Ok(result);
		}

		[HttpGet("movie/lookup/imdb/{imdbid}")] //broken
		public async Task<ActionResult<ServiceResponse<List<RadarrMovie>>>> GetMovieLookupImdb(string imdbid)
		{
			var result = await _radarrService.GetMovieLookupImdb(imdbid);
			return Ok(result);
		}

		[HttpGet("movie/lookup/tmdb/{tmdbid}")] //broken
		public async Task<ActionResult<ServiceResponse<List<RadarrMovie>>>> GetMovieLookupTmdb(string tmdbid)
		{
			var result = await _radarrService.GetMovieLookupTmdb(tmdbid);
			return Ok(result);
		}

		[HttpGet("wanted/missing")] //broken
		public async Task<ActionResult<ServiceResponse<List<RadarrMovie>>>> GetWantedMissing()
		{
			var result = await _radarrService.GetWantedMissing();
			return Ok(result);
		}

		[HttpGet("config/naming")]
		public async Task<ActionResult<ServiceResponse<NamingConfig>>> GetNamingConfig()
		{
			var result = await _radarrService.GetNamingConfig();
			return Ok(result);
		}

		[HttpGet("config/naming/{id}")] // no need
		public async Task<ActionResult<ServiceResponse<NamingConfig>>> GetNamingConfigById(int id)
		{
			var result = await _radarrService.GetNamingConfigById(id);
			return Ok(result);
		}
	}
}
