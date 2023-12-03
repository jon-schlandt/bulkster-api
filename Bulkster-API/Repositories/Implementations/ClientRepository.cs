using Bulkster_API.Data;
using Bulkster_API.Models.Repository;
using Bulkster_API.Models.Service;
using Bulkster_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bulkster_API.Repositories.Implementations;

public class ClientRepository : IClientRepository
{
    private readonly IBulksterDbContext _dbContext;

    public ClientRepository(IBulksterDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    #region Create
    
    public async Task<int> InsertClientAsync(ClientEntity entity)
    {
        await _dbContext.Client.AddAsync(entity);
        return await _dbContext.SaveChangesAsync();
    }
    
    #endregion
    
    #region Read

    public async Task<Client?> GetClientAsync(Guid clientId)
    {
        ClientEntity? entity = await _dbContext.Client.FirstOrDefaultAsync(c => c.ClientId == clientId);
        return entity?.ToServiceModel();
    }
    
    #endregion
    
    #region Update

    public async Task<int> UpdateClientAsync(ClientEntity entity)
    {
        _dbContext.Client.Update(entity);
        return await _dbContext.SaveChangesAsync();
    }
    
    #endregion
}
