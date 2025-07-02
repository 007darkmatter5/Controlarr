using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LogsController : ControllerBase
	{
		private readonly ILogService _logService;

		public LogsController(ILogService logService)
		{
			_logService = logService;
		}

		[HttpPost]
		public async Task<ActionResult<LogEntry>> Create(LogEntry request)
		{
			var result = await _logService.Create(request);
			return Ok(result);
		}

		[HttpGet]
		public async Task<ActionResult<List<LogEntry>>> GetAll()
		{
			var result = await _logService.GetAll();
			return Ok(result);
		}

		[HttpGet("{level}")]
		public async Task<ActionResult<LogEntry>> GetByLevel(string level)
		{
			var result = await _logService.GetByLevel(level);
			return Ok(result);
		}
	}
}
