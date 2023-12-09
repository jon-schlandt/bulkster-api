using Bulkster_API.Data;
using Bulkster_API.Models.Repository;
using Bulkster_API.Models.Service;
using Bulkster_API.Repositories.Interfaces;

namespace Bulkster_API.Repositories.Implementations;

public class MealRepository : IMealRepository
{
    private readonly IBulksterDbContext _dbContext;

    public MealRepository(IBulksterDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    #region Create
    
    public async Task<int> CreateMealAsync(CompleteMeal meal)
    {
        MealEntity entity = new MealEntity(meal);
        
        await _dbContext.Meal.AddAsync(entity);
        return await _dbContext.SaveChangesAsync();
    }
    
    #endregion
}
