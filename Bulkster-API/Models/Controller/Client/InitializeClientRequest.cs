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
}
