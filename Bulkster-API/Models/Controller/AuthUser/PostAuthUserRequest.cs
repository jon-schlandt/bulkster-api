using System.ComponentModel.DataAnnotations;

namespace Bulkster_API.Models.Controller.AuthUser;

public class PostAuthUserRequest
{
    [Required]
    [StringLength(24, MinimumLength = 1)]
    public string? AuthUserId { get; set; }
    
    [Required]
    [StringLength(255, MinimumLength = 1)]
    public string? Name { get; set; }
    
    [Required]
    [StringLength(255, MinimumLength = 1)]
    public string? Email { get; set; }
    
    [Required]
    public bool? EmailIsVerified { get; set; }
    
    [Required]
    public DateTime? UpdatedDateUtc { get; set; }
}
