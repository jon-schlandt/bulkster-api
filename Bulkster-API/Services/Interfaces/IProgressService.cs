using Bulkster_API.Models.Repository;
using Bulkster_API.Models.Service;

namespace Bulkster_API.Services.Interfaces;

public interface IProgressService
{
    public Task<ProgressLog?> GetProgressForToday(Guid clientId);

    public Task<Guid> LogProgressForToday(ProgressLog progressLog);
}
