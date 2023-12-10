using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bulkster_API.Models.Service;

namespace Bulkster_API.Models.Repository;

public class MealEntity
{
    [Key]
    [Column(TypeName = "binary(16)")]
    public Guid MealId { get; private set; }
    
    [ForeignKey("fk_meal_progressLogId")]
    [Column(TypeName = "binary(16)")]
    public Guid ProgressLogId { get; private set; }
    
    [Column(TypeName = "varchar(255)")]
    public string Name { get; private set; }
    
    [Column(TypeName = "smallint")]
    public short Calories { get; private set; }

    public MealEntity(Guid mealId, Guid progressLogId, string name, short calories)
    {
        MealId = mealId;
        ProgressLogId = progressLogId;
        Name = name;
        Calories = calories;
    }

    public MealEntity(CompleteMeal meal)
    {
        MealId = meal.Id;
        ProgressLogId = meal.ProgressLogId;
        Name = meal.Name;
        Calories = meal.Calories;
    }
}
