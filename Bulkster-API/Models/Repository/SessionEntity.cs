using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bulkster_API.Models.Service;

namespace Bulkster_API.Models.Repository;

public class SessionEntity
{
    [Key]
    [Column(TypeName = "binary(16)")]
    public Guid SessionId { get; private set; }
    
    [Required]
    [ForeignKey("fk_session_clientId")]
    [Column(TypeName = "binary(16)")]
    public Guid ClientId { get; private set; }
    
    [Required]
    [Column(TypeName = "datetime")]
    public DateTime LastSessionDate { get; set; }
    
    #region Constructors

    public SessionEntity(Guid sessionId, Guid clientId, DateTime lastSessionDate)
    {
        SessionId = sessionId;
        ClientId = clientId;
        LastSessionDate = lastSessionDate;
    }

    public SessionEntity(Session session)
    {
        SessionId = session.Id;
        ClientId = session.ClientId;
        LastSessionDate = session.LastSessionDate;
    }
    
    #endregion
}
