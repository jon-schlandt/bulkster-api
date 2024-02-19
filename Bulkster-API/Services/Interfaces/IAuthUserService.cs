using Bulkster_API.Models.Service;

namespace Bulkster_API.Services.Interfaces;

public interface IAuthUserService
{
    Task<string> CreateAuthUserAsync(AuthUser authUser);

    Task<bool> DoesAuthUserExistAsync(string authUserId);

    Task<AuthUser?> GetAuthUserByIdAsync(string authUserId);
}
