using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Syn.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class FeedController : ControllerBase
{
	[HttpGet("Test")]
	public IStatusCodeActionResult Test()
	{
		return new JsonResult(new { Status = "OK" });
	}
}
