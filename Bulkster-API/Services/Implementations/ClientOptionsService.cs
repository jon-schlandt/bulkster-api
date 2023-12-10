using Bulkster_API.Models.Service;
using Bulkster_API.Repositories.Interfaces;
using Bulkster_API.Services.Interfaces;

namespace Bulkster_API.Services.Implementations;

public class ClientOptionsService : IClientOptionsService
{
    private readonly IActivityLevelRepository _activityLevelRepository;
    private readonly IGenderRepository _genderRepository;

    public ClientOptionsService(IActivityLevelRepository activityLevelRepository, IGenderRepository genderRepository)
    {
        _activityLevelRepository = activityLevelRepository;
        _genderRepository = genderRepository;
    }
    
    public async Task<List<ActivityLevel>> GetActivityLevelOptionsAsync()
    {
        return (await _activityLevelRepository.GetActivityLevelsAsync()).ToList();
    }

    public async Task<List<Gender>> GetGenderOptionsAsync()
    {
        return (await _genderRepository.GetGendersAsync()).ToList();
    }

    public async Task<bool> DoesGenderOptionExist(Guid genderId)
    {
        return await _genderRepository.GetGenderById(genderId) != null;
    }

    public async Task<bool> DoesActivityLevelOptionExist(Guid activityLevelId)
    {
        return await _activityLevelRepository.GetActivityLevelById(activityLevelId) != null;
    } 
}
