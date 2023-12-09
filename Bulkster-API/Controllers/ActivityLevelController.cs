using Bulkster_API.Models.Controller.ClientOptions;
using Bulkster_API.Models.Service;
using Bulkster_API.Security;
using Bulkster_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bulkster_API.Controllers;

[Route("activity-level")]
[ApiController]
[RequireAppKey]
public class ActivityLevelController : ControllerBase
{
    private readonly IClientOptionsService _clientOptionsService;
    private readonly ILogger<GenderController> _logger;

    public ActivityLevelController(IClientOptionsService clientOptionsService, ILogger<GenderController> logger)
    {
        _clientOptionsService = clientOptionsService;
        _logger = logger;
    }

    [Route("options")]
    [HttpGet]
    public async Task<ActionResult<List<GetActivityLevelOptionResponse>>> GetActivityLevelOptionsAsync()
    {
        try
        {
            List<ActivityLevel> options = await _clientOptionsService.GetActivityLevelOptionsAsync();
            return Ok(options.Select(o => new GetActivityLevelOptionResponse(o)));
        }
        catch (Exception)
        {
            return StatusCode(500, new { Message = "An error occurred while getting activity level options." });
        }
    }
}
