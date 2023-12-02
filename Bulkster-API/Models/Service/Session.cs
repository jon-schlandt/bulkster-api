using Bulkster_API.Models.Repository;

namespace Bulkster_API.Models.Service;

public class Session
{
    public Guid Id { get; set; }
    
    public Guid ClientId { get; set; }
    
    public DateTime LastSessionDate { get; set; }
    
    #region Conversions

    public SessionEntity ToEntityModel()
    {
        return new SessionEntity
        {
            SessionId = Id,
            ClientId = ClientId,
            LastSessionDate = LastSessionDate
        };
    }
    
    #endregion
}
