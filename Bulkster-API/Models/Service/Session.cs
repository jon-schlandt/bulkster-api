using Bulkster_API.Models.Repository;

namespace Bulkster_API.Models.Service;

public class Session
{
    public Guid Id { get; }
    
    public Guid ClientId { get; }
    
    public DateTime LastSessionDate { get; set; }
    
    #region Constructors

    public Session(Guid id, Guid clientId, DateTime lastSessionDate)
    {
        Id = id;
        ClientId = clientId;
        LastSessionDate = lastSessionDate;
    }

    public Session(SessionEntity entity)
    {
        Id = entity.SessionId;
        ClientId = entity.ClientId;
        LastSessionDate = entity.LastSessionDate;
    }

    #endregion
}
