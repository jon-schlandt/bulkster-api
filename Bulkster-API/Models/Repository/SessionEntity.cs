using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bulkster_API.Models.Service;

namespace Bulkster_API.Models.Repository;

public class SessionEntity
{
    [Key]
    [Column(TypeName = "binary(16)")]
    public Guid SessionId { get; set; }
    
    [Required]
    [ForeignKey("fk_session_clientId")]
    [Column(TypeName = "binary(16)")]
    public Guid ClientId { get; set; }
    
    [Required]
    [Column(TypeName = "datetime")]
    public DateTime LastSessionDate { get; set; }

    #region Conversions
    
    public Session ToServiceModel()
    {
        return new Session
        {
            Id = SessionId,
            ClientId = ClientId,
            LastSessionDate = LastSessionDate
        };
    }
    
    #endregion
}
