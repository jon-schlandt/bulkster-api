using Bulkster_API.Data;
using Bulkster_API.Models.Repository;
using Bulkster_API.Models.Service;
using Bulkster_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bulkster_API.Repositories.Implementations;

public class ProgressLogRepository : IProgressLogRepository
{
    private readonly IBulksterDbContext _dbContext;

    public ProgressLogRepository(IBulksterDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    #region Create
    
    public async Task<int> InsertProgressLog(ProgressLogEntity entity)
    {
        _dbContext.ProgressLog.Add(entity);
        return await _dbContext.SaveChangesAsync();
    }
    
    #endregion
    
    #region Read
    
    public async Task<ProgressLog?> GetProgressLogForToday(Guid clientId)
    {
        ProgressLogEntity? entity = await _dbContext.ProgressLog.FirstOrDefaultAsync(p =>
            p.ClientId == clientId 
            && p.LogDate.Day == DateTime.UtcNow.Day);

        return entity?.ToServiceModel();
    }
    
    #endregion
    
    #region Update

    public async Task<int> UpdateProgressLog(ProgressLogEntity entity)
    {
        _dbContext.ProgressLog.Update(entity);
        return await _dbContext.SaveChangesAsync();
    }
    
    #endregion
}
