using Bulkster_API.Models.Controller.AuthUser;
using Bulkster_API.Models.Service;
using Bulkster_API.Security;
using Bulkster_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bulkster_API.Controllers;

[Route("auth-user")]
[ApiController]
[RequireApiKey]
public class AuthUserController : ControllerBase
{
    private readonly IAuthUserService _authUserService;
    
    public AuthUserController(IAuthUserService authUserService)
    {
        _authUserService = authUserService;
    }

    [HttpPost]
    public async Task<ActionResult<PostAuthUserResponse>> CreateAuthUserAsync([FromBody] PostAuthUserRequest request)
    {
        var authUser = new AuthUser(request);

        try
        {
            bool authUserExists = await _authUserService.DoesAuthUserExistAsync(authUser.Id);
            if (authUserExists)
            {
                var errMsg = $"Auth user with Id '{authUser.Id}' already exists.";
                return BadRequest(new { Message = errMsg });
            }
            
            string authUserId = await _authUserService.CreateAuthUserAsync(authUser);
            return Created("auth-user", new PostAuthUserResponse(authUserId));
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "An error occured while creating auth user." });
        }
    }
}
