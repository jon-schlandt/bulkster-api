using System.ComponentModel.DataAnnotations;
using Bulkster_API.Models.Controller.Meal;

namespace Bulkster_API.Models.Service;

public class Ingredient
{
    public Guid Id { get; set; }
    
    public Guid MealId { get; set; }
    
    public string Name { get; }
    
    public short Calories { get; }

    public Ingredient(LogIngredientRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.IngredientName))
        {
            const string errMsg = $"The {nameof(request.IngredientName)} field cannot be null or empty.";
            throw new ValidationException(errMsg);
        }

        if (request.Calories is null or <= 0)
        {
            const string errMsg = $"The {nameof(request.Calories)} field cannot be null or have a value less than 1.";
            throw new ValidationException(errMsg);
        }

        Name = request.IngredientName;
        Calories = request.Calories.GetValueOrDefault();
    }
}
