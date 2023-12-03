using Bulkster_API.Data;
using Bulkster_API.Models.Service;
using Bulkster_API.Repositories.Interfaces;
using Bulkster_API.Services.Interfaces;

namespace Bulkster_API.Services.Implementations;

public class ClientOptionsService : IClientOptionsService
{
    private readonly IActivityRepository _activityRepository;
    private readonly IGenderRepository _genderRepository;
    private readonly IBulksterDbContext _dbContext;

    public ClientOptionsService(
        IActivityRepository activityRepository,
        IGenderRepository genderRepository,
        IBulksterDbContext dbContext
    )
    {
        _activityRepository = activityRepository;
        _genderRepository = genderRepository;
        _dbContext = dbContext;
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
