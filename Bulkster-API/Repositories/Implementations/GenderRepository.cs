using Bulkster_API.Data;
using Bulkster_API.Models.Repository;
using Bulkster_API.Models.Service;
using Bulkster_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bulkster_API.Repositories.Implementations;

public class GenderRepository : IGenderRepository
{
    private readonly IBulksterDbContext _dbContext;
    
    public GenderRepository(IBulksterDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<Gender>> GetGendersAsync()
    {
        List<GenderEntity> entities = await _dbContext.Gender.ToListAsync();
        return entities.Select(e => e.ToServiceModel());
    }
}
