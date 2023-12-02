using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bulkster_API.Models.Service;

namespace Bulkster_API.Models.Repository;

public class ClientEntity
{
    [Key]
    [Column(TypeName = "binary(16)")]
    public Guid ClientId { get; set; }
    
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
    
    #region Conversions

    public Client ToServiceModel()
    {
        return new Client
        {
            Id = ClientId,
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
