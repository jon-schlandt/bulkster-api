using Bulkster_API.Models.Controller;
using Bulkster_API.Models.Repository;

namespace Bulkster_API.Models.Service;

public class ProgressLog
{
    public Guid Id { get; set; }
    
    public Guid ClientId { get; set; }
    
    public short CaloriesLogged { get; set; }
    
    public DateOnly LogDate { get; set; }
    
    #region Conversions

    public GetProgressResponse ToControllerModel()
    {
        return new GetProgressResponse
        {
            ClientId = ClientId,
            CaloriesLogged = CaloriesLogged,
            LogDate = LogDate
        };
    }

    public ProgressLogEntity ToRepositoryModel()
    {
        return new ProgressLogEntity
        {
            ProgressLogId = Id,
            ClientId = ClientId,
            CaloriesLogged = CaloriesLogged,
            LogDate = LogDate.ToDateTime(new TimeOnly(0, 0))
        };
    }
    
    #endregion
}
