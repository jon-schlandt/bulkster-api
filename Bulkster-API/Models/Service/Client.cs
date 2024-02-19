using Bulkster_API.Models.Controller.Client;
using Bulkster_API.Models.Repository;

namespace Bulkster_API.Models.Service;

public class Client
{
    #region Constructors

    public Client(PostClientRequest request)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }
        
        Id = Guid.NewGuid();
        AuthUserId = request.AuthUserId ?? string.Empty;
        GenderId = request.GenderId.GetValueOrDefault();
        Age = request.Age.GetValueOrDefault();
        Weight = request.Weight.GetValueOrDefault();
        Height = request.Height.GetValueOrDefault();
        ActivityLevelId = request.ActivityLevelId.GetValueOrDefault();
        CalorieModifier = request.CalorieModifier.GetValueOrDefault();
        DailyCalorieGoal = request.DailyCalorieGoal.GetValueOrDefault();
    }
    
    public Client(UpdateClientRequest request)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        Id = request.ClientId.GetValueOrDefault();
        AuthUserId = string.Empty;
        GenderId = request.GenderId.GetValueOrDefault();
        Age = request.Age.GetValueOrDefault();
        Weight = request.Weight.GetValueOrDefault();
        Height = request.Height.GetValueOrDefault();
        ActivityLevelId = request.ActivityLevelId.GetValueOrDefault();
        CalorieModifier = request.CalorieModifier.GetValueOrDefault();
        DailyCalorieGoal = request.DailyCalorieGoal.GetValueOrDefault();
    }

    public Client(ClientEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        
        Id = entity.ClientId;
        AuthUserId = entity.AuthUserId;
        GenderId = entity.GenderId;
        Age = entity.Age;
        Weight = entity.Weight;
        Height = entity.Height;
        ActivityLevelId = entity.ActivityLevelId;
        CalorieModifier = entity.CalorieModifier;
        DailyCalorieGoal = entity.DailyCalorieGoal;
    }
    
    public Client(
        Guid id,
        string authUserId,
        Guid genderId, 
        sbyte age, 
        short weight, 
        short height, 
        Guid activityLevelId, 
        short calorieModifier,
        short dailyCalorieGoal
    )
    {
        Id = id;
        AuthUserId = authUserId;
        GenderId = genderId;
        Age = age;
        Weight = weight;
        Height = height;
        ActivityLevelId = activityLevelId;
        CalorieModifier = calorieModifier;
        DailyCalorieGoal = dailyCalorieGoal;
    }

    #endregion
    
    public Guid Id{ get; private set; }
    
    public string AuthUserId { get; set; }
    
    public Guid GenderId { get; private set; }
    
    public sbyte Age { get; private set; }

    public short Weight { get; private set; }
    
    public short Height { get; private set; }
    
    public Guid ActivityLevelId { get; private set; }
    
    public short CalorieModifier { get; private set; }
    
    public short DailyCalorieGoal { get; private set; }
}
