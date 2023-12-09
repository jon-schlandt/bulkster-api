using Bulkster_API.Models.Service;

namespace Bulkster_API.Repositories.Interfaces;

public interface IClientRepository
{
    public Task<int> InsertClientAsync(Client client);

    public Task<Client?> GetClientAsync(Guid clientId);

    public Task<int> UpdateClientAsync(Client client);
}
