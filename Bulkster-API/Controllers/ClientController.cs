using Bulkster_API.Models.Controller.Client;
using Bulkster_API.Models.Service;
using Bulkster_API.Security;
using Bulkster_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bulkster_API.Controllers;

[Route("client")]
[ApiController]
[RequireApiKey]
public class ClientController : ControllerBase
{
    private readonly IAuthUserService _authUserService;
    private readonly IClientService _clientService;
    private readonly IClientOptionsService _clientOptionsService;
    private readonly ILogger<ClientController> _logger;

    public ClientController(
        IAuthUserService authUserService,
        IClientService clientService,
        IClientOptionsService clientOptionsService,
        ILogger<ClientController> logger
    )
    {
        _authUserService = authUserService;
        _clientService = clientService;
        _clientOptionsService = clientOptionsService;
        _logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult<PostClientResponse>> CreateClientAsync([FromBody] PostClientRequest request)
    {
        Client client = new Client(request);
        
        try
        {
            // Validate provided gender option is valid
            bool genderExists = await _clientOptionsService.DoesGenderOptionExist(client.GenderId);
            if (genderExists is false)
            {
                var errMsg = $"Gender with Id '{client.GenderId}' does not exist";
                return BadRequest(new { Message = errMsg });
            }

            // Validate provided activity level is valid
            bool activityLevelExists = await _clientOptionsService.DoesActivityLevelOptionExist(client.ActivityLevelId);
            if (activityLevelExists is false)
            {
                var errMsg = $"Activity level with Id '{client.ActivityLevelId}' does not exist";
                return BadRequest(new { Message =  errMsg });
            }

            // Validate provided auth user Id is associated to an existing auth user
            bool authUserExists = await _authUserService.DoesAuthUserExistAsync(client.AuthUserId);
            if (authUserExists is false)
            {
                var errMsg = $"Auth user with Id '{client.AuthUserId}' does not exist.";
                return BadRequest(new { Message = errMsg });
            }
            
            // Validate provided auth user Id is not already associated to a client
            bool clientExists = await _clientService.DoesClientExistAsync(client.AuthUserId);
            if (clientExists)
            {
                var errMsg = $"Auth user with Id '{client.AuthUserId}' is already associated to a client.";
                return BadRequest(new { Message = errMsg });
            }
            
            Guid clientId = await _clientService.CreateClientAsync(client);
            return Ok(new PostClientResponse(clientId));
        }
        catch (Exception)
        {
            return StatusCode(500, new { Message = "An error occured while creating client." });
        }
    }

    [HttpGet]
    public async Task<ActionResult<GetClientResponse>> GetClientAsync([FromQuery] GetClientRequest request)
    {
        string authUserId = request.AuthUserId ?? string.Empty;
        
        try
        {
            // Validate provided auth user Id is associated to an existing client
            Client? client = await _clientService.GetClientByAuthUserIdAsync(authUserId);
            if (client is not null)
            {
                return Ok(new GetClientResponse(client));
            }
            
            const string errMsg = "Client could not be found using the arguments supplied.";
            return NotFound(new { Message =  errMsg });
        }
        catch (Exception)
        {
            return StatusCode(500, new { Message = "An error occured while getting client." });
        }
    }

    [HttpPut]
    public async Task<ActionResult<UpdateClientResponse>> UpdateClientAsync([FromBody] UpdateClientRequest request)
    {
        Client client = new Client(request);
        
        try
        {
            // Validate provided client Id is associated to an existing client
            bool clientExists = await _clientService.DoesClientExistAsync(client.Id);
            if (clientExists is false)
            {
                var errMsg = $"Client with Id '{client.Id} does not exist.'";
                return NotFound(new { Message = errMsg });
            }
            
            // Validate provided gender option is valid
            bool genderExists = await _clientOptionsService.DoesGenderOptionExist(client.GenderId);
            if (genderExists is false)
            {
                var errMsg = $"Gender with Id '{client.GenderId}' does not exist";
                return BadRequest(new { Message = errMsg });
            }

            // Validate provided activity level is valid
            bool activityLevelExists = await _clientOptionsService.DoesActivityLevelOptionExist(client.ActivityLevelId);
            if (activityLevelExists is false)
            {
                var errMsg = $"Activity level with Id '{client.ActivityLevelId}' does not exist";
                return BadRequest(new { Message =  errMsg });
            }
            
            Guid clientId = await _clientService.UpdateClientAsync(client);
            return Ok(new UpdateClientResponse(clientId));
        }
        catch (Exception)
        {
            return StatusCode(500, new { Message = "An error occured while updating client." });
        }
    }
}
