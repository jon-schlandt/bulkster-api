using System.ComponentModel.DataAnnotations;
using Bulkster_API.Models.Controller.Client;
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
    public async Task<ActionResult<InitializeClientResponse>> InitializeClientAsync(
        [FromBody] InitializeClientRequest request)
    {
        Client client;
        try
        {
            client = new Client(request);
        }
        catch (ValidationException ex)
        {
            return BadRequest(new { ex.Message });
        }
        
        try
        {
            Guid clientId = await _clientService.InitializeClientAsync(client);
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
    public async Task<ActionResult<ClientLoginResponse>> LoginAsync([FromBody] ClientLoginRequest request)
    {
        Guid clientId = request.ClientId.GetValueOrDefault();
        if (clientId == Guid.Empty)
        {
            BadRequest(new { Message = $"The {nameof(request.ClientId)} field cannot be null or empty." });
        }
        
        try
        {
            Client? client = await _clientService.GetClientAsync(clientId);
            if (client == null)
            {
                return NotFound(new { Message = $"Client with Id '{clientId}' could not be found." });
            }

            await _sessionService.RefreshSessionAsync(client.Id);
            return Ok(new ClientLoginResponse(client));
        }
        catch (Exception)
        {
            return StatusCode(500, new { Message = "An error occured while while logging in." });
        }
    }

    [HttpPut]
    public async Task<ActionResult<UpdateClientResponse>> UpdateClientAsync([FromBody] UpdateClientRequest request)
    {
        Client client;
        try
        {
            client = new Client(request);
        }
        catch (ValidationException ex)
        {
            return BadRequest(new { ex.Message });
        }
        
        try
        {
            Guid clientId = await _clientService.UpdateClientAsync(client);
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
