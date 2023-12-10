using Bulkster_API.Models.Service;

namespace Bulkster_API.Repositories.Interfaces;

public interface IGenderRepository
{
    public Task<Gender?> GetGenderById(Guid genderId);
    
    public Task<IEnumerable<Gender>> GetGendersAsync();
}
