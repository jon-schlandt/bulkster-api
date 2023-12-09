using Bulkster_API.Models.Service;

namespace Bulkster_API.Models.Controller.ClientOptions;

public class GetGenderOptionResponse
{
    public Guid GenderId { get; set; }
    
    public string DisplayName { get; set; }
    
    #region Constructors

    public GetGenderOptionResponse(Gender gender)
    {
        GenderId = gender.Id;
        DisplayName = gender.DisplayName;
    }
    
    #endregion
}
