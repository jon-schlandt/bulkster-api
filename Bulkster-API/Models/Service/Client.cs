using Bulkster_API.Models.Repository;

namespace Bulkster_API.Models.Service;

public class Client
{
    public Guid Id{ get; private set; }
    
    public Guid GenderId { get; private set; }
    
    public byte Age { get; private set; }

    public short Weight { get; private set; }
    
    public short Height { get; private set; }
    
    public Guid ActivityLevelId { get; private set; }
    
    public short CalorieModifier { get; private set; }
    
    public short DailyCalorieGoal { get; private set; }

    #region Constructors

    public Client(
        Guid id,
        Guid genderId, 
        byte age, 
        short weight, 
        short height, 
        Guid activityLevelId, 
        short calorieModifier,
        short dailyCalorieGoal
    )
    {
        Id = id;
        GenderId = genderId;
        Age = age;
        Weight = weight;
        Height = height;
        ActivityLevelId = activityLevelId;
        CalorieModifier = calorieModifier;
        DailyCalorieGoal = dailyCalorieGoal;
    }

    public Client(ClientEntity entity)
    {
        Id = entity.ClientId;
        GenderId = entity.GenderId;
        Age = entity.Age;
        Weight = entity.Weight;
        Height = entity.Height;
        ActivityLevelId = entity.ActivityLevelId;
        CalorieModifier = entity.CalorieModifier;
        DailyCalorieGoal = entity.DailyCalorieGoal;
    }

    #endregion
}
