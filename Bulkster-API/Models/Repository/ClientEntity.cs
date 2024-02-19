using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bulkster_API.Models.Service;

namespace Bulkster_API.Models.Repository;

public class ClientEntity
{
    #region Constructors

    public ClientEntity(
        Guid clientId,
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
        ClientId = clientId;
        AuthUserId = authUserId;
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
        AuthUserId = client.AuthUserId;
        GenderId = client.GenderId;
        Age = client.Age;
        Weight = client.Weight;
        Height = client.Height;
        ActivityLevelId = client.ActivityLevelId;
        CalorieModifier = client.CalorieModifier;
        DailyCalorieGoal = client.DailyCalorieGoal;
    }
    
    #endregion
    
    [Key]
    [Column(TypeName = "binary(16)")]
    public Guid ClientId { get; private set; }
    
    [ForeignKey("fk_client_authUserId")]
    [Column(TypeName = "varchar(24)")]
    public string AuthUserId { get; set; }
    
    [ForeignKey("fk_client_genderId")]
    [Column(TypeName = "binary(16)")]
    public Guid GenderId { get; set; }
    
    [Column(TypeName = "tinyint")]
    public sbyte Age { get; set; }
    
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
}
