using Bulkster_API.Data;
using Bulkster_API.Models.Repository;
using Bulkster_API.Models.Service;
using Bulkster_API.Repositories.Interfaces;

namespace Bulkster_API.Repositories.Implementations;

public class IngredientRepository : IIngredientRepository
{
    private readonly IBulksterDbContext _dbContext;

    public IngredientRepository(IBulksterDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> CreateIngredientsAsync(IEnumerable<Ingredient> ingredients)
    {
        List<IngredientEntity> entities = ingredients.Select(i => new IngredientEntity(i)).ToList();
        
        await _dbContext.Ingredient.AddRangeAsync(entities);
        return await _dbContext.SaveChangesAsync();
    }
}
