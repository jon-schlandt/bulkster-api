using Bulkster_API.Data;
using Bulkster_API.Models.Service;
using Bulkster_API.Repositories.Interfaces;
using Bulkster_API.Services.Interfaces;

namespace Bulkster_API.Services.Implementations;

public class ClientService : IClientService
{
    private readonly ISessionService _sessionService;
    private readonly IClientRepository _clientRepository;
    private readonly IBulksterDbContext _dbContext;
    
    public ClientService(
        ISessionService sessionService,
        IClientRepository clientRepository,
        IBulksterDbContext dbContext
    )
    {
        _sessionService = sessionService;
        _clientRepository = clientRepository;
        _dbContext = dbContext;
    }
    
    public async Task<Guid> InitializeClientAsync(Client client)
    {
        await using var transaction = await _dbContext.BeginTransactionAsync();
        try
        {
            await _clientRepository.InsertClientAsync(client);
            await _sessionService.RefreshSessionAsync(client.Id);

            await transaction.CommitAsync();
            return client.Id;
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<Client?> LoginClientAsync(Guid clientId)
    {
        Client? client = await GetClientAsync(clientId);
        if (client == null)
        {
            return null;
        }

        await _sessionService.RefreshSessionAsync(clientId);
        return client;
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
