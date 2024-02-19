using Bulkster_API.Models.Service;

namespace Bulkster_API.Repositories.Interfaces;

public interface IClientRepository
{
    Task<int> InsertClientAsync(Client client);

    Task<Client?> GetClientByIdAsync(Guid clientId);

    Task<Client?> GetClientByAuthUserIdAsync(string authUserId);

    Task<int> UpdateClientAsync(Client client);
}
