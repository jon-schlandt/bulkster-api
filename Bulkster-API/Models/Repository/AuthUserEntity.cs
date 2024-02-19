using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bulkster_API.Models.Service;

namespace Bulkster_API.Models.Repository;

public class AuthUserEntity
{
    #region Constructors

    public AuthUserEntity
    (
        string authUserId,
        string name,
        string email,
        bool emailVerified,
        DateTime updatedDateUtc
    )
    {
        AuthUserId = authUserId;
        Name = name;
        Email = email;
        EmailVerified = emailVerified;
        UpdatedDateUtc = updatedDateUtc;
    }

    public AuthUserEntity(AuthUser authUser)
    {
        AuthUserId = authUser.Id;
        Name = authUser.Name;
        Email = authUser.Email;
        EmailVerified = authUser.EmailIsVerified;
        UpdatedDateUtc = authUser.UpdatedDateUtc;
    }

    #endregion
    
    [Key]
    [Column(TypeName = "varchar(24)")]
    public string AuthUserId { get; set; }
    
    [Column(TypeName = "varchar(255)")]
    public string Name { get; set; }
    
    [Column(TypeName = "varchar(255)")]
    public string Email { get; set; }
    
    [Column(TypeName = "bit(1)")]
    public bool EmailVerified { get; set; }
    
    [Column(TypeName = "datetime")]
    public DateTime UpdatedDateUtc { get; set; }
}
