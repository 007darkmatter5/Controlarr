using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NodesController : ControllerBase
	{
		private readonly INodeService _nodeService;

		public NodesController(INodeService nodeService)
		{
			_nodeService = nodeService;
		}

		[HttpPost]
		public async Task<ActionResult<Node>> Create(NodeCreateRequest request)
		{
			var result = await _nodeService.Create(request);
			return Ok(result);
		}

		[HttpGet]
		public async Task<ActionResult<List<Node>>> GetAllActive()
		{
			var result = await _nodeService.GetAllActive();
			return Ok(result);
		}

		[HttpGet("inactive")]
		public async Task<ActionResult<List<Node>>> GetAllInactive()
		{
			var result = await _nodeService.GetAllInactive();
			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Node>> GetById(int id)
		{
			var result = await _nodeService.GetById(id);
			return Ok(result);
		}

		[HttpGet("alias/{applicationAlias}")]
		public async Task<ActionResult<Node>> GetByApplicationAlias(string applicationAlias)
		{
			var result = await _nodeService.GetByApplicationAlias(applicationAlias);
			return Ok(result);
		}

		[HttpGet("parent/{parentApplicationName}")]
		public async Task<ActionResult<Node>> GetByParentApplication(string parentApplicationName)
		{
			var result = await _nodeService.GetByParentApplication(parentApplicationName);
			return Ok(result);
		}

		[HttpGet("version/{id}")]
		public async Task<ActionResult<ServiceResponse<NodeResponse?>>> GetVersion(int id)
		{
			var result = await _nodeService.GetVersion(id);
			if (!result.Success)
			{
				return NotFound(result);
			}
			return Ok(result);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<List<Node>>> HardDeleteById(int id)
		{
			var result = await _nodeService.HardDeleteById(id);
			return Ok(result);
		}

		[HttpPut("restore/{id}")]
		public async Task<ActionResult<List<Node>>> RestoreById(int id)
		{
			var result = await _nodeService.RestoreById(id);
			return Ok(result);
		}

		[HttpPut("softdelete/{id}")]
		public async Task<ActionResult<List<Node>>> SoftDeleteId(int id)
		{
			var result = await _nodeService.SoftDeleteById(id);
			return Ok(result);
		}

		[HttpPut]
		public async Task<ActionResult<List<Node>>> Update(NodeUpdateRequest request)
		{
			var result = await _nodeService.Update(request);
			return Ok(result);
		}
	}
}
