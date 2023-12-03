using Bulkster_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Bulkster_API.Models.Controller;
using Bulkster_API.Models.Service;
using Bulkster_API.Security;

namespace Bulkster_API.Controllers;

[Route("progress")]
[ApiController]
[RequireAppKey]
public class ProgressController : ControllerBase
{
    private readonly IClientService _clientService;
    private readonly IProgressService _progressService;

    public ProgressController(IClientService clientService, IProgressService progressService)
    {
        _clientService = clientService;
        _progressService = progressService;
    }
    
    [Route("today")]
    [HttpGet]
    public async Task<IActionResult> GetProgressForTodayAsync([Required] Guid clientId)
    {
        try
        {
            Client? client = await _clientService.GetClientAsync(clientId);
            if (client == null)
            {
                return NotFound(new { Message = $"Client with Id '{clientId}' could not be found." });
            }

            ProgressLog? progressForToday = await _progressService.GetProgressForTodayAsync(clientId);
            if (progressForToday == null)
            {
                return NotFound(new { Message = $"Client does not have progress logged for today." });
            }

            return Ok(progressForToday.ToControllerModel());
        }
        catch (Exception)
        {
            return StatusCode(500, new { Message = "An error occured while getting progress for client." });
        }
    }

    [Route("today")]
    [HttpPut]
    public async Task<IActionResult> LogProgressForTodayAsync([Required][FromBody] LogProgressRequest request)
    {
        try
        {
            Client? client = await _clientService.GetClientAsync(request.ClientId);
            if (client == null)
            {
                return NotFound(new { Message = $"Client with Id '{request.ClientId}' could not be found." });
            }

            Guid progressLogId = await _progressService.LogProgressForTodayAsync(request.ToServiceModel());
            return Ok(new LogProgressResponse
            {
                ProgressLogId = progressLogId
            });
        }
        catch (Exception)
        {
            return StatusCode(500, new { Message = "An error occured while logging progress for client." });
        }
    }
}
