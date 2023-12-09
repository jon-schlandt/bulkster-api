using Bulkster_API.Models.Controller.ClientOptions;
using Bulkster_API.Models.Service;
using Bulkster_API.Security;
using Bulkster_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bulkster_API.Controllers;

[Route("gender")]
[ApiController]
[RequireAppKey]
public class GenderController : ControllerBase
{
    private readonly IClientOptionsService _clientOptionsService;
    private readonly ILogger<GenderController> _logger;

    public GenderController(IClientOptionsService clientOptionsService, ILogger<GenderController> logger)
    {
        _clientOptionsService = clientOptionsService;
        _logger = logger;
    }

    [Route("options")]
    [HttpGet]
    public async Task<ActionResult<List<GetGenderOptionResponse>>> GetGenderOptionsAsync()
    {
        try
        {
            List<Gender> options = await _clientOptionsService.GetGenderOptionsAsync();
            return Ok(options.Select(o => new GetGenderOptionResponse(o)));
        }
        catch (Exception)
        {
            return StatusCode(500, new { Message = "An error occurred while getting gender options." });
        }
    }
}
