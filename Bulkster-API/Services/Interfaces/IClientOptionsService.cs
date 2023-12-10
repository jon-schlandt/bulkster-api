using Bulkster_API.Models.Repository;
using Bulkster_API.Models.Service;

namespace Bulkster_API.Services.Interfaces;

public interface IClientOptionsService
{
    public Task<List<ActivityLevel>> GetActivityLevelOptionsAsync();
    
    public Task<List<Gender>> GetGenderOptionsAsync();

    public Task<bool> DoesGenderOptionExist(Guid genderId);

    public Task<bool> DoesActivityLevelOptionExist(Guid activityLevelId);
}
