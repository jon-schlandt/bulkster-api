using Bulkster_API.Models.Repository;

namespace Bulkster_API.Models.Service;

public class Gender
{
    public Guid Id { get; }
    
    public string DisplayName { get; }

    public Gender(GenderEntity entity)
    {
        Id = entity.GenderId;
        DisplayName = entity.DisplayName;
    }
}
