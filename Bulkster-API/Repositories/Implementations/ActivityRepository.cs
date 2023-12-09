using Bulkster_API.Data;
using Bulkster_API.Models.Repository;
using Bulkster_API.Models.Service;
using Bulkster_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bulkster_API.Repositories.Implementations;

public class ActivityRepository : IActivityRepository
{
    private readonly IBulksterDbContext _dbContext;

    public ActivityRepository(IBulksterDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<ActivityLevel>> GetActivityLevelsAsync()
    {
        List<ActivityLevelEntity> entities = await _dbContext.ActivityLevel.ToListAsync();
        return entities.Select(e => new ActivityLevel(e));
    }
}
