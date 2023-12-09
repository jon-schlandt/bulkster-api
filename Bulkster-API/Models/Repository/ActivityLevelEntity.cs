using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bulkster_API.Models.Service;

namespace Bulkster_API.Models.Repository;

public class ActivityLevelEntity
{
    [Key]
    [Column(TypeName = "binary(16)")]
    public Guid ActivityLevelId { get; }
    
    [Required]
    [Column(TypeName = "varchar(10)")]
    public string DisplayName { get; }
    
    [Required]
    [Column(TypeName = "varchar(255)")]
    public string Description { get; }
    
    #region Constructors

    public ActivityLevelEntity(ActivityLevel activityLevel)
    {
        ActivityLevelId = activityLevel.Id;
        DisplayName = activityLevel.DisplayName;
        Description = activityLevel.Description;
    }
    
    #endregion
}
