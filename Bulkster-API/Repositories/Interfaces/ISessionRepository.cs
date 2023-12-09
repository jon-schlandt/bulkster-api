using Bulkster_API.Models.Service;

namespace Bulkster_API.Repositories.Interfaces;

public interface ISessionRepository
{
    public Task<int> InsertSessionAsync(Session session);

    public Task<Session?> GetSessionByClientIdAsync(Guid clientId);

    public Task<int> UpdateSessionAsync(Session session);
}
