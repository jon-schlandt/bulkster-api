using Bulkster_API.Models.Controller;
using Bulkster_API.Models.Repository;

namespace Bulkster_API.Models.Service;

public class Client
{
    public Guid Id { get; set; }
    
    public Guid GenderId { get; set; }
    
    public byte Age { get; set; }

    public short Weight { get; set; }
    
    public short Height { get; set; }
    
    public Guid ActivityLevelId { get; set; }
    
    public short CalorieModifier { get; set; }
    
    public short DailyCalorieGoal { get; set; }

    #region Conversions

    public ClientLoginResponse ToControllerModel()
    {
        return new ClientLoginResponse
        {
            ClientId = Id,
            GenderId = GenderId,
            Age = Age,
            Weight = Weight,
            Height = Height,
            ActivityLevelId = ActivityLevelId,
            CalorieModifier = CalorieModifier,
            DailyCalorieGoal = DailyCalorieGoal
        };
    }
    
    public ClientEntity ToEntityModel()
    {
        return new ClientEntity
        {
            ClientId = Id,
            GenderId = GenderId,
            Age = Age,
            Weight = Weight,
            Height = Height,
            ActivityLevelId = ActivityLevelId,
            CalorieModifier = CalorieModifier,
            DailyCalorieGoal = DailyCalorieGoal
        };
    }
    
    #endregion
}
