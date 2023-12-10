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
    
    public async Task<int> InsertProgressLogAsync(ProgressLog progressLog)
    {
        var entity = new ProgressLogEntity(progressLog);
        
        _dbContext.ProgressLog.Add(entity);
        return await _dbContext.SaveChangesAsync();
    }
    
    #endregion
    
    #region Read
    
    public async Task<ProgressLog?> GetProgressLogForTodayAsync(Guid clientId)
    {
        ProgressLogEntity? entity = await _dbContext.ProgressLog.FirstOrDefaultAsync(p =>
            p.ClientId == clientId 
            && p.LogDate.Day == DateTime.UtcNow.Day);

        return entity != null ? new ProgressLog(entity): null;
    }
    
    #endregion
    
    #region Update

    public async Task<int> UpdateProgressLogAsync(ProgressLog progressLog)
    {
        var entity = await _dbContext.ProgressLog
            .FirstOrDefaultAsync(p => p.ProgressLogId == progressLog.Id);

        if (entity == null)
        {
            return 0;
        }

        entity.ProgressLogId = progressLog.Id.GetValueOrDefault();
        entity.ClientId = progressLog.ClientId;
        entity.CaloriesLogged = progressLog.CaloriesLogged;
        entity.LogDate = progressLog.LogDate;
            
        _dbContext.ProgressLog.Update(entity);
        return await _dbContext.SaveChangesAsync();
    }
    
    #endregion
}
