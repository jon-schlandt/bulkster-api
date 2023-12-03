using Bulkster_API.Models.Repository;
using Bulkster_API.Models.Service;

namespace Bulkster_API.Services.Interfaces;

public interface IProgressService
{
    public Task<ProgressLog?> GetProgressForTodayAsync(Guid clientId);

    public Task<Guid> LogProgressForTodayAsync(ProgressLog progressLog);
}
