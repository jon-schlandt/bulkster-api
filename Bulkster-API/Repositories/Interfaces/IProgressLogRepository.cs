using Bulkster_API.Models.Repository;
using Bulkster_API.Models.Service;

namespace Bulkster_API.Repositories.Interfaces;

public interface IProgressLogRepository
{
    public Task<int> InsertProgressLogAsync(ProgressLog progressLog);
    
    public Task<ProgressLog?> GetProgressLogForTodayAsync(Guid clientId);

    public Task<int> UpdateProgressLogAsync(ProgressLog progressLog);
}
