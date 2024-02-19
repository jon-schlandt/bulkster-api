using Bulkster_API.Data;
using Bulkster_API.Models.Repository;
using Bulkster_API.Models.Service;
using Bulkster_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bulkster_API.Repositories.Implementations;

public class AuthUserRepository : IAuthUserRepository
{
    private readonly IBulksterDbContext _dbContext;

    public AuthUserRepository(IBulksterDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<int> CreateAuthUserAsync(AuthUser authUser)
    {
        var entity = new AuthUserEntity(authUser);
        
        await _dbContext.AuthUser.AddAsync(entity);
        return await _dbContext.SaveChangesAsync();
    }
    
    public async Task<AuthUser?> GetAuthUserByIdAsync(string authUserId)
    {
        AuthUserEntity? entity = await _dbContext.AuthUser
            .FirstOrDefaultAsync(c => c.AuthUserId == authUserId);
        
        return entity != null ? new AuthUser(entity) : null;
    }
}
