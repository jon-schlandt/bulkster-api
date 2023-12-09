using Bulkster_API.Models.Service;
using Bulkster_API.Repositories.Interfaces;
using Bulkster_API.Services.Interfaces;

namespace Bulkster_API.Services.Implementations;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;
    private readonly ISessionRepository _sessionRepository;
    
    public ClientService(
        IClientRepository clientRepository,
        ISessionRepository sessionRepository
    )
    {
        _clientRepository = clientRepository;
        _sessionRepository = sessionRepository;
    }
    
    public async Task<Guid> InitializeClientAsync(Client client)
    {
        client.Id = Guid.NewGuid();

        var session = new Session(
            id: Guid.NewGuid(),
            clientId: client.Id,
            lastSessionDate: DateTime.UtcNow
        );
        
        await _clientRepository.InsertClientAsync(client);
        await _sessionRepository.InsertSessionAsync(session);

        return client.Id;
    }

    public async Task<Client?> GetClientAsync(Guid clientId)
    {
        return await _clientRepository.GetClientAsync(clientId);
    }

    public async Task<Guid> UpdateClientAsync(Client client)
    {
        await _clientRepository.UpdateClientAsync(client);
        return client.Id;
    }
}
