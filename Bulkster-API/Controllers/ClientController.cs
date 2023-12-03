using System.ComponentModel.DataAnnotations;
using Bulkster_API.Models.Controller;
using Bulkster_API.Models.Service;
using Bulkster_API.Security;
using Bulkster_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bulkster_API.Controllers;

[Route("client")]
[ApiController]
[RequireAppKey]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;
    private readonly ISessionService _sessionService;
    private readonly ILogger<ClientController> _logger;

    public ClientController(
        IClientService clientService,
        ISessionService sessionService,
        ILogger<ClientController> logger
    )
    {
        _clientService = clientService;
        _sessionService = sessionService;
        _logger = logger;
    }

    [Route("initialize")]
    [HttpPost]
    public async Task<ActionResult> InitializeClientAsync([FromBody] InitializeClientRequest request)
    {
        try
        {
            Guid clientId = await _clientService.InitializeClientAsync(request.ToServiceModel());
            return Ok(new InitializeClientResponse
            {
                ClientId = clientId
            });
        }
        catch (Exception)
        {
            return StatusCode(500, new { Message = "An error occured while initializing client." });
        }
    }

    [Route("login")]
    [HttpGet]
    public async Task<ActionResult> LoginAsync([Required] Guid clientId)
    {
        try
        {
            Client? client = await _clientService.GetClientAsync(clientId);
            if (client == null)
            {
                return NotFound(new { Message = $"Client with Id '{clientId}' could not be found." });
            }

            await _sessionService.RefreshSessionAsync(client.Id);
            return Ok(client.ToControllerModel());
        }
        catch (Exception)
        {
            return StatusCode(500, new { Message = "An error occured while while logging in." });
        }
    }

    [HttpPut]
    public async Task<ActionResult> UpdateClientAsync([FromBody] UpdateClientRequest request)
    {
        try
        {
            Guid clientId = await _clientService.UpdateClientAsync(request.ToServiceModel());
            return Ok(new UpdateClientResponse
            {
                ClientId = clientId
            });
        }
        catch (Exception)
        {
            return StatusCode(500, new { Message = "An error occured while updating client." });
        }
    }
}
