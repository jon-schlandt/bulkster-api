using System.ComponentModel.DataAnnotations;

namespace Bulkster_API.Models.Controller.Client;

public class ClientLoginRequest
{
    [Required]
    public Guid? ClientId { get; set; }
}
