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

    public async Task<Gender?> GetGenderById(Guid genderId)
    {
        GenderEntity? entity = await _dbContext.Gender.FirstOrDefaultAsync(g => g.GenderId == genderId);
        return entity != null ? new Gender(entity) : null;
    }
    
    public async Task<IEnumerable<Gender>> GetGendersAsync()
    {
        List<GenderEntity> entities = await _dbContext.Gender.ToListAsync();
        return entities.Select(e => new Gender(e));
    }
}
