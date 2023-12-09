using Bulkster_API.Models.Service;

namespace Bulkster_API.Services.Interfaces;

public interface IMealService
{
    public Task<Guid> LogMealAsync(CompleteMeal meal);
}
