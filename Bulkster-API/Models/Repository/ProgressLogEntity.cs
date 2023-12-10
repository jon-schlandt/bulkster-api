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
    
    #region Constructors

    public ProgressLogEntity(Guid progressLogId, Guid clientId, short caloriesLogged, DateTime logDate)
    {
        ProgressLogId = progressLogId;
        ClientId = clientId;
        CaloriesLogged = caloriesLogged;
        LogDate = logDate;
    }

    public ProgressLogEntity(ProgressLog progressLog)
    {
        ProgressLogId = progressLog.Id.GetValueOrDefault();
        ClientId = progressLog.ClientId;
        CaloriesLogged = progressLog.CaloriesLogged;
        LogDate = progressLog.LogDate;
    }
    
    #endregion
}
