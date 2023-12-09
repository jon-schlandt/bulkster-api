using Bulkster_API.Models.Service;

namespace Bulkster_API.Models.Controller.Progress;

public class GetProgressResponse
{
    public Guid ProgressLogId { get; set; }
    
    public Guid ClientId { get; set; }
    
    public short CaloriesLogged { get; set; }
    
    public DateOnly LogDate { get; set; }
    
    #region Constructors

    public GetProgressResponse(ProgressLog progressLog)
    {
        ProgressLogId = progressLog.Id.GetValueOrDefault();
        ClientId = progressLog.ClientId;
        CaloriesLogged = progressLog.CaloriesLogged;
        LogDate = progressLog.LogDate;
    }
    
    #endregion
}
