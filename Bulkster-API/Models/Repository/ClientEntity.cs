using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bulkster_API.Models.Service;

namespace Bulkster_API.Models.Repository;

public class ClientEntity
{
    [Key]
    [Column(TypeName = "binary(16)")]
    public Guid ClientId { get; private set; }
    
    [ForeignKey("fk_client_genderId")]
    [Column(TypeName = "binary(16)")]
    public Guid GenderId { get; set; }
    
    [Column(TypeName = "tinyint")]
    public byte Age { get; set; }
    
    [Column(TypeName = "smallint")]
    public short Weight { get; set; }
    
    [Column(TypeName = "smallint")]
    public short Height { get; set; }
    
    [ForeignKey("fk_client_activityLevelId")]
    [Column(TypeName = "binary(16)")]
    public Guid ActivityLevelId { get; set; }
    
    [Column(TypeName = "smallint")]
    public short CalorieModifier { get; set; }
    
    [Column(TypeName = "smallint")]
    public short DailyCalorieGoal { get; set; }
    
    #region Constructors

    public ClientEntity(
        Guid clientId, 
        Guid genderId, 
        byte age, 
        short weight, 
        short height, 
        Guid activityLevelId,
        short calorieModifier, 
        short dailyCalorieGoal
    )
    {
        ClientId = clientId;
        GenderId = genderId;
        Age = age;
        Weight = weight;
        Height = height;
        ActivityLevelId = activityLevelId;
        CalorieModifier = calorieModifier;
        DailyCalorieGoal = dailyCalorieGoal;
    }

    public ClientEntity(Client client)
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
