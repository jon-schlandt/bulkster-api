using Bulkster_API.Models.Repository;

namespace Bulkster_API.Models.Service;

public class ActivityLevel
{
    public Guid Id { get; }
    
    public string DisplayName { get; }
    
    public string Description { get; }

    #region Constructors

    public ActivityLevel(ActivityLevelEntity entity)
    {
        Id = entity.ActivityLevelId;
        DisplayName = entity.DisplayName;
        Description = entity.Description;
    }

    #endregion
}
