using Bulkster_API.Models.Service;
using Bulkster_API.Repositories.Interfaces;
using Bulkster_API.Services.Interfaces;

namespace Bulkster_API.Services.Implementations;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;
    
    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    #region Create

    public async Task<Guid> CreateClientAsync(Client client)
    {
        await _clientRepository.InsertClientAsync(client);
        return client.Id;
    }

    #endregion

    #region Read

    public async Task<bool> DoesClientExistAsync(Guid clientId)
    {
        Client? client = await GetClientByIdAsync(clientId);
        return client != null;
    }

    public async Task<bool> DoesClientExistAsync(string authUserId)
    {
        Client? client = await GetClientByAuthUserIdAsync(authUserId);
        return client != null;
    }

    public async Task<Client?> GetClientByIdAsync(Guid clientId)
    {
        return await _clientRepository.GetClientByIdAsync(clientId);
    }

    public async Task<Client?> GetClientByAuthUserIdAsync(string authUserId)
    {
        return await _clientRepository.GetClientByAuthUserIdAsync(authUserId);
    }

    #endregion

    #region Update

    public async Task<Guid> UpdateClientAsync(Client client)
    {
        if (client == null)
        {
            throw new ArgumentNullException(nameof(client));
        }
        
        // Get matching client and set auth user Id
        Client? existingClient = await GetClientByIdAsync(client.Id);
        if (existingClient is null)
        {
            var errMsg = $"Client with Id '{client.Id}' does not exist.";
            throw new Exception(errMsg);
        }

        client.AuthUserId = existingClient.AuthUserId;
        
        await _clientRepository.UpdateClientAsync(client);
        return client.Id;
    }

    #endregion
}
