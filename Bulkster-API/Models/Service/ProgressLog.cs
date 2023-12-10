using Bulkster_API.Models.Repository;

namespace Bulkster_API.Models.Service;

public class ProgressLog
{
    public Guid? Id { get; set; }
    
    public Guid ClientId { get; }
    
    public short CaloriesLogged { get; set; }
    
    public DateTime LogDate { get; }
    
    #region Constructors

    public ProgressLog(Guid? id, Guid clientId, short caloriesLogged, DateTime logDate)
    {
        Id = id;
        ClientId = clientId;
        CaloriesLogged = caloriesLogged;
        LogDate = logDate;
    }

    public ProgressLog(ProgressLogEntity entity)
    {
        Id = entity.ProgressLogId;
        ClientId = entity.ClientId;
        CaloriesLogged = entity.CaloriesLogged;
        LogDate = entity.LogDate;
    }
    
    #endregion
}
