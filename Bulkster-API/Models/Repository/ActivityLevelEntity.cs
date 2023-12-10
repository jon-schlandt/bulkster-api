using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bulkster_API.Models.Service;

namespace Bulkster_API.Models.Repository;

public class ActivityLevelEntity
{
    [Key]
    [Column(TypeName = "binary(16)")]
    public Guid ActivityLevelId { get; private set; }
    
    [Required]
    [Column(TypeName = "varchar(10)")]
    public string DisplayName { get; private set; }
    
    [Required]
    [Column(TypeName = "varchar(255)")]
    public string Description { get; private set; }
    
    #region Constructors

    public ActivityLevelEntity(Guid activityLevelId, string displayName, string description)
    {
        ActivityLevelId = activityLevelId;
        DisplayName = displayName;
        Description = description;
    }

    public ActivityLevelEntity(ActivityLevel activityLevel)
    {
        ActivityLevelId = activityLevel.Id;
        DisplayName = activityLevel.DisplayName;
        Description = activityLevel.Description;
    }
    
    #endregion
}
