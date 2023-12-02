using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bulkster_API.Models.Service;

namespace Bulkster_API.Models.Repository;

public class ActivityLevelEntity
{
    [Key]
    [Column(TypeName = "binary(16)")]
    public Guid ActivityLevelId { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(10)")]
    public string? DisplayName { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(255)")]
    public string? Description { get; set; }

    public ActivityLevel ToServiceModel()
    {
        return new ActivityLevel
        {
            Id = ActivityLevelId,
            DisplayName = DisplayName,
            Description = Description
        };
    }
}
