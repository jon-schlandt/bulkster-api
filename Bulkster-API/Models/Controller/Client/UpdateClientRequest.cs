using System.ComponentModel.DataAnnotations;

namespace Bulkster_API.Models.Controller.Client;

public class UpdateClientRequest
{
    [Required]
    public Guid? ClientId { get; set; }
    
    [Required]
    public Guid? GenderId { get; set; }
    
    [Required]
    [Range(1, byte.MaxValue, ErrorMessage = $"The {nameof(Age)} field cannot have a value less than 1.")]
    public sbyte? Age { get; set; }

    [Required]
    [Range(1, short.MaxValue, ErrorMessage = $"The {nameof(Weight)} field cannot have a value less than 1.")]
    public short? Weight { get; set; }
    
    [Required]
    [Range(1, short.MaxValue, ErrorMessage = $"The {nameof(Height)} field cannot have a value less than 1.")]
    public short? Height { get; set; }
    
    [Required]
    public Guid? ActivityLevelId { get; set; }
    
    [Required]
    public short? CalorieModifier { get; set; }
    
    [Required]
    [Range(1, short.MaxValue, ErrorMessage = $"The {nameof(DailyCalorieGoal)} field cannot have a value less than 1.")]
    public short? DailyCalorieGoal { get; set; }
}
