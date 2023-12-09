using System.ComponentModel.DataAnnotations;

namespace Bulkster_API.Models.Controller.Meal;

public class LogMealRequest
{
    [Required]
    public Guid? ClientId { get; set; }

    [Required]
    [StringLength(255, MinimumLength = 1)]
    public string? MealName { get; set; }

    [Required]
    public List<LogIngredientRequest>? Ingredients { get; set; }
}
