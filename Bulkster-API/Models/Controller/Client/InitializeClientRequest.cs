using System.ComponentModel.DataAnnotations;

namespace Bulkster_API.Models.Controller.Client;

public class InitializeClientRequest
{
    [Required]
    public Guid? GenderId { get; set; }
    
    [Required]
    public byte? Age { get; set; }
    
    [Required]
    public short? Weight { get; set; }
    
    [Required]
    public short? Height { get; set; }
    
    [Required]
    public Guid? ActivityLevelId { get; set; }
    
    [Required]
    public short? CalorieModifier { get; set; }
    
    [Required]
    public short? DailyCalorieGoal { get; set; }

    #region Conversions
    
    public Service.Client ToServiceModel()
    {
        string? validationErr = null;
        
        if (GenderId == null || GenderId == Guid.Empty)
        {
            validationErr = $"The {nameof(GenderId)} field cannot be null or empty.";
        }

        if (Age is null or <= 0)
        {
            validationErr = $"The {nameof(Age)} field cannot be null or have a value less than 1.";
        }

        if (Weight is null or <= 0)
        {
            validationErr = $"The {nameof(Weight)} field cannot be null or have a value less than 1.";
        }

        if (Height is null or <= 0)
        {
            validationErr = $"The {nameof(Height)} field cannot be null or have a value less than 1.";
        }

        if (ActivityLevelId == null || ActivityLevelId == Guid.Empty)
        { 
            validationErr = $"The {nameof(ActivityLevelId)} field cannot be null or empty.";
        }

        if (CalorieModifier is null)
        {
            validationErr = $"The {nameof(CalorieModifier)} field cannot be null.";
        }

        if (DailyCalorieGoal is null or <= 0)
        {
            validationErr = $"The {nameof(DailyCalorieGoal)} field cannot be null or have a value less than 1.";
        }

        if (validationErr != null)
        {
            throw new ValidationException(validationErr);
        }

        return new Service.Client(
            id: Guid.NewGuid(),
            genderId: GenderId.GetValueOrDefault(),
            age: Age.GetValueOrDefault(),
            weight: Weight.GetValueOrDefault(),
            height: Height.GetValueOrDefault(),
            activityLevelId: ActivityLevelId.GetValueOrDefault(),
            calorieModifier: CalorieModifier.GetValueOrDefault(),
            dailyCalorieGoal: DailyCalorieGoal.GetValueOrDefault()
        );
    }
    
    #endregion
}
