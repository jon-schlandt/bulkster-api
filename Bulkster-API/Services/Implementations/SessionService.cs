using Bulkster_API.Models.Service;
using Bulkster_API.Repositories.Interfaces;
using Bulkster_API.Services.Interfaces;

namespace Bulkster_API.Services.Implementations;

public class SessionService : ISessionService
{
    private readonly ISessionRepository _sessionRepository;

    public SessionService(ISessionRepository sessionRepository)
    {
        _sessionRepository = sessionRepository;
    }
    
    public async Task<Guid> RefreshSessionAsync(Guid clientId)
    {
        Session? session = await _sessionRepository.GetSessionByClientIdAsync(clientId);
        if (session == null)
        {
            session = new Session(
                id: Guid.NewGuid(), 
                clientId: clientId, 
                lastSessionDate: DateTime.UtcNow
            );
            
            await _sessionRepository.InsertSessionAsync(session);
        }
        else
        {
            session.LastSessionDate = DateTime.UtcNow;
            await _sessionRepository.UpdateSessionAsync(session);
        }

        return session.Id;
    }
}
