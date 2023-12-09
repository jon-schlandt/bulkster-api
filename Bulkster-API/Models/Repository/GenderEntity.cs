using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bulkster_API.Models.Service;

namespace Bulkster_API.Models.Repository;

public class GenderEntity
{
    [Key]
    [Column("GenderId", TypeName = "binary(16)")]
    public Guid GenderId { get; }
    
    [Required]
    [Column("DisplayName", TypeName = "varchar(10)")]
    public string DisplayName { get; }

    public GenderEntity(Gender gender)
    {
        GenderId = gender.Id;
        DisplayName = gender.DisplayName;
    }
}
