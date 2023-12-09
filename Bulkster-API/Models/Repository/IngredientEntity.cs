using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bulkster_API.Models.Service;

namespace Bulkster_API.Models.Repository;

public class IngredientEntity
{
    [Key]
    [Column(TypeName = "binary(16)")]
    public Guid IngredientId { get; set; }
    
    [ForeignKey("fk_ingredient_mealId")]
    [Column(TypeName = "binary(16)")]
    public Guid MealId { get; set; }
    
    [Column(TypeName = "varchar(255)")]
    public string Name { get; set; }
    
    [Column(TypeName = "smallint")]
    public short Calories { get; set; }

    public IngredientEntity(Guid ingredientId, Guid mealId, string name, short calories)
    {
        IngredientId = ingredientId;
        MealId = mealId;
        Name = name;
        Calories = calories;
    }
    
    public IngredientEntity(Ingredient ingredient)
    {
        IngredientId = ingredient.Id;
        MealId = ingredient.MealId;
        Name = ingredient.Name;
        Calories = ingredient.Calories;
    }
}
