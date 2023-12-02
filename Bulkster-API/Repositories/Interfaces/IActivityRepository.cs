using Bulkster_API.Models.Service;

namespace Bulkster_API.Repositories.Interfaces;

public interface IActivityRepository
{
    public Task<IEnumerable<ActivityLevel>> GetActivityLevelsAsync();
}
