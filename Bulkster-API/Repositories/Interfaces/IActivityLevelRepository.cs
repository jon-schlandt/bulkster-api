using Bulkster_API.Models.Service;

namespace Bulkster_API.Repositories.Interfaces;

public interface IActivityLevelRepository
{
    public Task<ActivityLevel?> GetActivityLevelById(Guid activityLevelId);
    
    public Task<IEnumerable<ActivityLevel>> GetActivityLevelsAsync();
}
