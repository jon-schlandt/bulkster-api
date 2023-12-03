using Bulkster_API.Models.Repository;
using Bulkster_API.Models.Service;

namespace Bulkster_API.Repositories.Interfaces;

public interface IClientRepository
{
    public Task<int> InsertClientAsync(ClientEntity entity);

    public Task<Client?> GetClientAsync(Guid clientId);

    public Task<int> UpdateClientAsync(ClientEntity entity);
}
