using Bulkster_API.Models.Repository;
using Bulkster_API.Models.Service;

namespace Bulkster_API.Services.Interfaces;

public interface IClientService
{
    Task<Guid> CreateClientAsync(Client client);

    Task<bool> DoesClientExistAsync(Guid clientId);

    Task<bool> DoesClientExistAsync(string authUserId);

    Task<Client?> GetClientByIdAsync(Guid clientId);

    Task<Client?> GetClientByAuthUserIdAsync(string authUserId);

    Task<Guid> UpdateClientAsync(Client client);
}
