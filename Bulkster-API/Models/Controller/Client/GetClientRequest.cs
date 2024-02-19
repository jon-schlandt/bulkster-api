using System.ComponentModel.DataAnnotations;

namespace Bulkster_API.Models.Controller.Client;

public class GetClientRequest
{
    [Required]
    public string? AuthUserId { get; set; }
}
