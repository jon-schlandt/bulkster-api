using Bulkster_API.Models.Repository;
using Bulkster_API.Models.Service;

namespace Bulkster_API.Services.Interfaces;

public interface IClientOptionsService
{
    public Task<List<ActivityLevel>> GetActivityLevelOptions();
    
    public Task<List<Gender>> GetGenderOptions();
}
