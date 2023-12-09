using Bulkster_API.Models.Service;

namespace Bulkster_API.Repositories.Interfaces;

public interface IIngredientRepository
{
    public Task<int> CreateIngredientsAsync(IEnumerable<Ingredient> ingredients);
}
