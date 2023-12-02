using Bulkster_API.Models.Controller;

namespace Bulkster_API.Models.Service;

public class ActivityLevel
{
    public Guid Id { get; set; }
    
    public string? DisplayName { get; set; }
    
    public string? Description { get; set; }

    public GetActivityLevelOptionsResponse ToControllerModel()
    {
        return new GetActivityLevelOptionsResponse
        {
            ActivityLevelId = Id,
            DisplayName = DisplayName,
            Description = Description
        };
    }
}
