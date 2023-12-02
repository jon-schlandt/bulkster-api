using Bulkster_API.Models.Controller;

namespace Bulkster_API.Models.Service;

public class Gender
{
    public Guid Id { get; set; }
    
    public string? DisplayName { get; set; }

    public GetGenderOptionResponse ToControllerModel()
    {
        return new GetGenderOptionResponse
        {
            GenderId = Id,
            DisplayName = DisplayName
        };
    }
}
