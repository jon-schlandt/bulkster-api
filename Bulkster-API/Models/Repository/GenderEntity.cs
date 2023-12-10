using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bulkster_API.Models.Service;

namespace Bulkster_API.Models.Repository;

public class GenderEntity
{
    [Key]
    [Column("GenderId", TypeName = "binary(16)")]
    public Guid GenderId { get; private set; }
    
    [Required]
    [Column("DisplayName", TypeName = "varchar(10)")]
    public string DisplayName { get; private set; }

    #region Constructors

    public GenderEntity(Guid genderId, string displayName)
    {
        GenderId = genderId;
        DisplayName = displayName;
    }
    
    public GenderEntity(Gender gender)
    {
        GenderId = gender.Id;
        DisplayName = gender.DisplayName;
    }
    
    #endregion
}
