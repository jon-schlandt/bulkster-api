using Bulkster_API.Models.Repository;

namespace Bulkster_API.Models.Service;

public class ProgressLog
{
    public Guid? Id { get; set; }
    
    public Guid ClientId { get; }
    
    public short CaloriesLogged { get; set; }
    
    public DateOnly LogDate { get; }
    
    #region Constructors

    public ProgressLog(Guid? id, Guid clientId, short caloriesLogged, DateOnly logDate)
    {
        Id = id;
        ClientId = clientId;
        CaloriesLogged = caloriesLogged;
        LogDate = logDate;
    }

    public ProgressLog(ProgressLogEntity entity)
    {
        Id = entity.ClientId;
        ClientId = entity.ClientId;
        CaloriesLogged = entity.CaloriesLogged;
        LogDate = DateOnly.FromDateTime(entity.LogDate);
    }
    
    #endregion
}
