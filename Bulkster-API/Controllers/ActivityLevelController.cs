using Bulkster_API.Models.Service;
using Bulkster_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bulkster_API.Controllers;

[Route("activity-level")]
[ApiController]
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
    public async Task<ActionResult> GetActivityLevelOptions()
    {
        List<ActivityLevel> options = await _clientOptionsService.GetActivityLevelOptions();
        return Ok(options.Select(o => o.ToControllerModel()));
    }
}
