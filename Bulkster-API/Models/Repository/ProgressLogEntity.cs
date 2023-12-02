using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bulkster_API.Models.Service;

namespace Bulkster_API.Models.Repository;

public class ProgressLogEntity
{
    [Key]
    [Column(TypeName = "binary(16)")]
    public Guid ProgressLogId { get; set; }
    
    [ForeignKey("fk_progressLog_clientId")]
    [Column(TypeName = "binary(16)")]
    public Guid ClientId { get; set; }
    
    [Column(TypeName = "smallint")]
    public short CaloriesLogged { get; set; }
    
    [Column(TypeName = "datetime")]
    public DateTime LogDate { get; set; }
    
    #region Conversions

    public ProgressLog ToServiceModel()
    {
        return new ProgressLog
        {
            Id = ProgressLogId,
            ClientId = ClientId,
            CaloriesLogged = CaloriesLogged,
            LogDate = DateOnly.FromDateTime(LogDate)
        };
    }
    
    #endregion
}
