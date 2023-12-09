using System.ComponentModel.DataAnnotations;

namespace Bulkster_API.Models.Controller.Meal;

public class LogIngredientRequest
{
    [Required]
    [StringLength(255, MinimumLength = 1)]
    public string? IngredientName { get; set; }
    
    [Required]
    public short? Calories { get; set; }
}
