using Bulkster_API.Models.Repository;
using Bulkster_API.Models.Service;

namespace Bulkster_API.Repositories.Interfaces;

public interface ISessionRepository
{
    public Task<int> InsertSessionAsync(SessionEntity entity);

    public Task<Session?> GetSessionByClientIdAsync(Guid clientId);

    public Task<int> UpdateSessionAsync(SessionEntity entity);
}
