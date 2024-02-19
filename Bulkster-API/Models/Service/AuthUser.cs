using System.ComponentModel.DataAnnotations;
using Bulkster_API.Models.Controller.AuthUser;
using Bulkster_API.Models.Repository;

namespace Bulkster_API.Models.Service;

public class AuthUser
{
    #region Constructor

    public AuthUser(PostAuthUserRequest request)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }
        
        Id = request.AuthUserId ?? string.Empty;
        Name = request.Name ?? string.Empty;
        Email = request.Email ?? string.Empty;
        EmailIsVerified = request.EmailIsVerified.GetValueOrDefault();
        UpdatedDateUtc = request.UpdatedDateUtc.GetValueOrDefault();
    }

    public AuthUser(AuthUserEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        
        Id = entity.AuthUserId;
        Name = entity.Name;
        Email = entity.Email;
        EmailIsVerified = entity.EmailVerified;
        UpdatedDateUtc = entity.UpdatedDateUtc;
    }

    #endregion
    
    public string Id { get; private set; }
    
    public string Name { get; private set; }
    
    public string Email { get; private set; }
    
    public bool EmailIsVerified { get; private set; }
    
    public DateTime UpdatedDateUtc { get; private set; }
}
