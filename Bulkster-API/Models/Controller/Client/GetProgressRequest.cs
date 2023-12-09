using System.ComponentModel.DataAnnotations;

namespace Bulkster_API.Models.Controller.Client;

public class GetProgressRequest
{
    [Required]
    public Guid? ClientId { get; set; }
}
