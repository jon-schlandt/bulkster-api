using Bulkster_API.Models.Service;

namespace Bulkster_API.Models.Controller.ClientOptions;

public class GetActivityLevelOptionResponse
{
    public Guid ActivityLevelId { get; set; }
    
    public string DisplayName { get; set; }
    
    public string Description { get; set; }

    #region Constructors

    public GetActivityLevelOptionResponse(ActivityLevel activityLevel)
    {
        ActivityLevelId = activityLevel.Id;
        DisplayName = activityLevel.DisplayName;
        Description = activityLevel.Description;
    }

    #endregion
}
