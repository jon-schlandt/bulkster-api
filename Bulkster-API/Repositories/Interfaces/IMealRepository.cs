using Bulkster_API.Models.Service;

namespace Bulkster_API.Repositories.Interfaces;

public interface IMealRepository
{
    public Task<int> CreateMealAsync(CompleteMeal meal);
}
