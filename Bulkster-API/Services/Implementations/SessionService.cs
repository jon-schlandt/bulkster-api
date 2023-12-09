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
    
    public async Task<int> RefreshSessionAsync(Guid clientId)
    {
        Session? session = await _sessionRepository.GetSessionByClientIdAsync(clientId);
        if (session == null)
        {
            session = new Session(
                id: Guid.NewGuid(), 
                clientId: clientId, 
                lastSessionDate: DateTime.UtcNow
            );
            
            return await _sessionRepository.InsertSessionAsync(session);
        }
        
        session.LastSessionDate = DateTime.UtcNow;
        return await _sessionRepository.UpdateSessionAsync(session);
    }
}
