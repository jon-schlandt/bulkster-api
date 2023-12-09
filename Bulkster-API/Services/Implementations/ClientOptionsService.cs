using Bulkster_API.Models.Service;
using Bulkster_API.Repositories.Interfaces;
using Bulkster_API.Services.Interfaces;

namespace Bulkster_API.Services.Implementations;

public class ClientOptionsService : IClientOptionsService
{
    private readonly IActivityRepository _activityRepository;
    private readonly IGenderRepository _genderRepository;

    public ClientOptionsService(IActivityRepository activityRepository, IGenderRepository genderRepository)
    {
        _activityRepository = activityRepository;
        _genderRepository = genderRepository;
    }
    
    public async Task<List<ActivityLevel>> GetActivityLevelOptionsAsync()
    {
        return (await _activityRepository.GetActivityLevelsAsync()).ToList();
    }

    public async Task<List<Gender>> GetGenderOptionsAsync()
    {
        return (await _genderRepository.GetGendersAsync()).ToList();
    }
}
