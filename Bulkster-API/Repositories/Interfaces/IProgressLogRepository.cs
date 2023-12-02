using Bulkster_API.Models.Repository;
using Bulkster_API.Models.Service;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Bulkster_API.Repositories.Interfaces;

public interface IProgressLogRepository
{
    public Task<int> InsertProgressLog(ProgressLogEntity entity);
    public Task<ProgressLog?> GetProgressLogForToday(Guid clientId);

    public Task<int> UpdateProgressLog(ProgressLogEntity entity);
}
