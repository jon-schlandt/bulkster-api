using Bulkster_API.Models.Service;
using Bulkster_API.Repositories.Interfaces;
using Bulkster_API.Services.Interfaces;

namespace Bulkster_API.Services.Implementations;

public class AuthUserService : IAuthUserService
{
    private readonly IAuthUserRepository _authUserRepository;

    public AuthUserService(IAuthUserRepository authUserRepository)
    {
        _authUserRepository = authUserRepository;
    }
    
    public async Task<string> CreateAuthUserAsync(AuthUser authUser)
    {
        await _authUserRepository.CreateAuthUserAsync(authUser);
        return authUser.Id;
    }
    
    public async Task<bool> DoesAuthUserExistAsync(string authUserId)
    {
        AuthUser? authUser = await GetAuthUserByIdAsync(authUserId);
        return authUser != null;
    }

    public async Task<AuthUser?> GetAuthUserByIdAsync(string authUserId)
    {
        return await _authUserRepository.GetAuthUserByIdAsync(authUserId);
    }
}
