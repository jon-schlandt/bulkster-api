using Bulkster_API.Models.Repository;
using Bulkster_API.Models.Service;

namespace Bulkster_API.Services.Interfaces;

public interface IClientService
{
    public Task<Guid> InitializeClientAsync(Client client);

    public Task<Client?> LoginClientAsync(Guid clientId);

    public Task<Client?> GetClientAsync(Guid clientId);

    public Task<Guid> UpdateClientAsync(Client client);
}
