using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bulkster_API.Models.Service;

namespace Bulkster_API.Models.Repository;

public class GenderEntity
{
    [Key]
    [Column("GenderId", TypeName = "binary(16)")]
    public Guid GenderId { get; set; }
    
    [Required]
    [Column("DisplayName", TypeName = "varchar(10)")]
    public string? DisplayName { get; set; }
    
    #region Conversions

    public Gender ToServiceModel()
    {
        return new Gender
        {
            Id = GenderId,
            DisplayName = DisplayName
        };
    }
    
    #endregion
}
