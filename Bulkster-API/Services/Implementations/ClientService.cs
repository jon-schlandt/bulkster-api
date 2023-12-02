using Bulkster_API.Data;
using Bulkster_API.Models.Service;
using Bulkster_API.Repositories.Interfaces;
using Bulkster_API.Services.Interfaces;

namespace Bulkster_API.Services.Implementations;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;
    private readonly ISessionRepository _sessionRepository;
    private readonly IBulksterDbContext _dbContext;
    
    public ClientService(
        IClientRepository clientRepository,
        ISessionRepository sessionRepository,
        IBulksterDbContext dbContext
    )
    {
        _clientRepository = clientRepository;
        _sessionRepository = sessionRepository;
        _dbContext = dbContext;
    }
    
    public async Task<Guid> InitializeClientAsync(Client client)
    {
        client.Id = Guid.NewGuid();
        
        var session = new Session
        {
            Id = Guid.NewGuid(),
            ClientId = client.Id,
            LastSessionDate = DateTime.UtcNow
        };
        
        await _clientRepository.InsertClientAsync(client.ToEntityModel());
        await _sessionRepository.InsertSessionAsync(session.ToEntityModel());

        return client.Id;
    }

    public async Task<Client?> GetClientAsync(Guid clientId)
    {
        return await _clientRepository.GetClientAsync(clientId);
    }

    public async Task<Guid> UpdateClientAsync(Client client)
    {
        _dbContext.Client.Update(client.ToEntityModel());
        await _dbContext.SaveChangesAsync();
        
        return client.Id;
    }
}
