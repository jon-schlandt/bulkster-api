using System.ComponentModel.DataAnnotations;
using Bulkster_API.Models.Service;

namespace Bulkster_API.Models.Controller;

public class LogProgressRequest
{
    [Required]
    public Guid ClientId { get; set; }
    
    [Required]
    public short CaloriesToLog { get; set; }

    #region Conversions
    
    public ProgressLog ToServiceModel()
    {
        return new ProgressLog
        {
            ClientId = ClientId,
            CaloriesLogged = CaloriesToLog,
            LogDate = DateOnly.FromDateTime(DateTime.UtcNow)
        };
    }
    
    #endregion
}
