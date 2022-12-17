using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Syn.Shared.Models.Feeds;
using FeedReader = CodeHollow.FeedReader.FeedReader;

namespace Syn.Server.Controllers;
[ApiController, Route("api/[controller]")]
public class FeedsController : ControllerBase
{
	private readonly ILogger<FeedsController> _logger;

	public FeedsController(ILogger<FeedsController> logger)
	{
		_logger = logger;
	}

	[HttpGet("")]
	public async Task<IStatusCodeActionResult> GetFeed([FromQuery] string url)
	{
		_logger.LogInformation("Feed read requested for {url}", url);
		var codeHollowFeed = await FeedReader.ReadAsync(url);
		return codeHollowFeed is null ? NotFound() : Ok(new Feed(url, codeHollowFeed));
	}
}
