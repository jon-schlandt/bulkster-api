namespace Bulkster_API.Models.Controller.Client;

public class ClientLoginResponse
{
    public Guid ClientId { get; set; }
    
    public Guid GenderId { get; set; }
    
    public byte Age { get; set; }
    
    public short Weight { get; set; }
    
    public short Height { get; set; }
    
    public Guid ActivityLevelId { get; set; }
    
    public short CalorieModifier { get; set; }
    
    public short DailyCalorieGoal { get; set; }

    #region Constructors

    public ClientLoginResponse(Service.Client client)
    {
        ClientId = client.Id;
        GenderId = client.GenderId;
        Age = client.Age;
        Weight = client.Weight;
        Height = client.Height;
        ActivityLevelId = client.ActivityLevelId;
        CalorieModifier = client.CalorieModifier;
        DailyCalorieGoal = client.DailyCalorieGoal;
    }

    #endregion
}
