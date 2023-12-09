using System.ComponentModel.DataAnnotations;
using Bulkster_API.Models.Controller;
using Bulkster_API.Models.Controller.Meal;

namespace Bulkster_API.Models.Service;

public class CompleteMeal
{
    public Guid Id { get; set; }
    
    public Guid ClientId { get; }
    
    public Guid ProgressLogId { get; set; }
    
    public string Name { get; }
    
    public short Calories { get; set; }
    
    public List<Ingredient> Ingredients { get; }
    
    public CompleteMeal(LogMealRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.MealName))
        {
            const string errMsg = $"The {nameof(request.MealName)} field cannot be null or empty.";
            throw new ValidationException(errMsg);
        }

        if (request.Ingredients == null || !request.Ingredients.Any())
        {
            const string errMsg = $"The {nameof(request.Ingredients)} field cannot be null or empty.";
            throw new ValidationException(errMsg);
        }

        ClientId = request.ClientId.GetValueOrDefault();
        Name = request.MealName;
        Ingredients = request.Ingredients.Select(i => new Ingredient(i)).ToList();
    }
}
