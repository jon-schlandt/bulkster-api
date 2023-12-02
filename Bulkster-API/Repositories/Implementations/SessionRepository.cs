using Bulkster_API.Data;
using Bulkster_API.Models.Repository;
using Bulkster_API.Models.Service;
using Bulkster_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bulkster_API.Repositories.Implementations;

public class SessionRepository : ISessionRepository
{
    private readonly IBulksterDbContext _dbContext;

    public SessionRepository(IBulksterDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    #region Create
    
    public async Task<int> InsertSessionAsync(SessionEntity entity)
    {
        await _dbContext.Session.AddAsync(entity);
        return await _dbContext.SaveChangesAsync();
    }
    
    #endregion
    
    #region Read

    public async Task<Session?> GetSessionByClientIdAsync(Guid clientId)
    {
        SessionEntity? entity = await _dbContext.Session.FirstOrDefaultAsync(s => s.ClientId == clientId);
        return entity?.ToServiceModel();
    }
    
    #endregion
    
    #region Update

    public async Task<int> UpdateSessionAsync(SessionEntity entity)
    {
        _dbContext.Session.Update(entity);
        return await _dbContext.SaveChangesAsync();
    }
    
    #endregion
}
