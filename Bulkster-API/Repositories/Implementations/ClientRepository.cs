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
    
    public async Task<int> InsertClientAsync(Client client)
    {
        var entity = new ClientEntity(client);
        
        await _dbContext.Client.AddAsync(entity);
        return await _dbContext.SaveChangesAsync();
    }
    
    #endregion
    
    #region Read

    public async Task<Client?> GetClientByIdAsync(Guid clientId)
    {
        ClientEntity? entity = await _dbContext.Client.FirstOrDefaultAsync(c => c.ClientId == clientId);
        return entity != null ? new Client(entity) : null;
    }

    public async Task<Client?> GetClientByAuthUserIdAsync(string authUserId)
    {
        ClientEntity? entity = await _dbContext.Client.FirstOrDefaultAsync(c => c.AuthUserId == authUserId);
        return entity != null ? new Client(entity) : null;
    }
    
    #endregion
    
    #region Update

    public async Task<int> UpdateClientAsync(Client client)
    {
        ClientEntity? entity = await _dbContext.Client
            .FirstOrDefaultAsync(c => c.ClientId == client.Id);

        if (entity == null)
        {
            return 0;
        }

        // Update mutable properties only
        entity.GenderId = client.GenderId;
        entity.Age = client.Age;
        entity.Weight = client.Weight;
        entity.Height = client.Height;
        entity.ActivityLevelId = client.ActivityLevelId;
        entity.CalorieModifier = client.CalorieModifier;
        entity.DailyCalorieGoal = client.DailyCalorieGoal;
        
        _dbContext.Client.Update(entity);
        return await _dbContext.SaveChangesAsync();
    }
    
    #endregion
}
