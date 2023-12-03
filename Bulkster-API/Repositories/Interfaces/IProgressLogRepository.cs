using Bulkster_API.Models.Repository;
using Bulkster_API.Models.Service;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Bulkster_API.Repositories.Interfaces;

public interface IProgressLogRepository
{
    public Task<int> InsertProgressLogAsync(ProgressLogEntity entity);
    public Task<ProgressLog?> GetProgressLogForTodayAsync(Guid clientId);

    public Task<int> UpdateProgressLogAsync(ProgressLogEntity entity);
}
