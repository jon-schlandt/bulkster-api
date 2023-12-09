using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bulkster_API.Models.Service;

namespace Bulkster_API.Models.Repository;

public class ClientEntity
{
    [Key]
    [Column(TypeName = "binary(16)")]
    public Guid ClientId { get; }
    
    [ForeignKey("fk_client_genderId")]
    [Column(TypeName = "binary(16)")]
    public Guid GenderId { get; }
    
    [Column(TypeName = "tinyint")]
    public byte Age { get; }
    
    [Column(TypeName = "smallint")]
    public short Weight { get; }
    
    [Column(TypeName = "smallint")]
    public short Height { get; }
    
    [ForeignKey("fk_client_activityLevelId")]
    [Column(TypeName = "binary(16)")]
    public Guid ActivityLevelId { get; }
    
    [Column(TypeName = "smallint")]
    public short CalorieModifier { get; }
    
    [Column(TypeName = "smallint")]
    public short DailyCalorieGoal { get; }
    
    #region Constructors

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
