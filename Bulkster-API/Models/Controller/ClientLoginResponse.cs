namespace Bulkster_API.Models.Controller;

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
}
