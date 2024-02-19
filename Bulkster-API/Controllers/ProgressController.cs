using Bulkster_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Bulkster_API.Models.Controller.Client;
using Bulkster_API.Models.Controller.Progress;
using Bulkster_API.Models.Service;
using Bulkster_API.Security;

namespace Bulkster_API.Controllers;

[Route("progress")]
[ApiController]
[RequireApiKey]
public class ProgressController : ControllerBase
{
    private readonly IClientService _clientService;
    private readonly IProgressService _progressService;
    private readonly ILogger<ProgressController> _logger;

    public ProgressController(
        IClientService clientService, 
        IProgressService progressService,
        ILogger<ProgressController> logger)
    {
        _clientService = clientService;
        _progressService = progressService;
        _logger = logger;
    }
    
    [Route("today")]
    [HttpGet]
    public async Task<ActionResult<GetProgressResponse>> GetProgressForTodayAsync(
        [FromQuery] GetProgressRequest request)
    {
        Guid clientId = request.ClientId.GetValueOrDefault();
        if (clientId == Guid.Empty)
        {
            return BadRequest(new { Message = $"The {nameof(request.ClientId)} field cannot be null or empty." });
        }
        
        try
        {
            Client? client = await _clientService.GetClientByIdAsync(clientId);
            if (client == null)
            {
                return NotFound(new { Message = $"Client with Id '{clientId}' could not be found." });
            }

            ProgressLog? progressLog = await _progressService.GetProgressForTodayAsync(clientId);
            if (progressLog == null)
            {
                return NotFound(new { Message = "Client does not have progress logged for today." });
            }

            return Ok(new GetProgressResponse(progressLog));
        }
        catch (Exception)
        {
            return StatusCode(500, new { Message = "An error occured while getting progress for client." });
        }
    }
}
