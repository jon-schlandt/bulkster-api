using Bulkster_API.Models.Service;

namespace Bulkster_API.Repositories.Interfaces;

public interface IAuthUserRepository
{
    Task<int> CreateAuthUserAsync(AuthUser authUser);
    
    Task<AuthUser?> GetAuthUserByIdAsync(string authUserId);
}
