using Bulkster_API.Data;
using Bulkster_API.Models.Service;
using Bulkster_API.Repositories.Interfaces;
using Bulkster_API.Services.Interfaces;

namespace Bulkster_API.Services.Implementations;

public class MealService : IMealService
{
    private readonly IProgressService _progressService;
    private readonly IIngredientRepository _ingredientRepository;
    private readonly IMealRepository _mealRepository;
    private readonly IBulksterDbContext _dbContext;

    public MealService(
        IProgressService progressService,
        IIngredientRepository ingredientRepository, 
        IMealRepository mealRepository,
        IBulksterDbContext dbContext
    )
    {
        _progressService = progressService;
        _ingredientRepository = ingredientRepository;
        _mealRepository = mealRepository;
        _dbContext = dbContext;
    }
    
    public async Task<Guid> LogMealAsync(CompleteMeal meal)
    {
        meal.Id = Guid.NewGuid();
        meal.Calories = (short)meal.Ingredients.Sum(i => i.Calories);
        
        meal.Ingredients.ForEach(i =>
        {
            i.Id = Guid.NewGuid();
            i.MealId = meal.Id;
        });

        var progressLog = new ProgressLog(
            id: null,
            clientId: meal.ClientId,
            caloriesLogged: meal.Calories,
            logDate: DateTime.Now
        );

        await using var transaction = await _dbContext.Database.BeginTransactionAsync();
        try
        {
            meal.ProgressLogId = await _progressService.LogProgressForTodayAsync(progressLog);
            await _mealRepository.CreateMealAsync(meal);
            await _ingredientRepository.CreateIngredientsAsync(meal.Ingredients);
            
            await transaction.CommitAsync();
            return Guid.NewGuid();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}
