using Bulkster_API.Models.Service;
using Bulkster_API.Repositories.Interfaces;
using Bulkster_API.Services.Interfaces;

namespace Bulkster_API.Services.Implementations;

public class ProgressService : IProgressService
{
    private readonly IProgressLogRepository _progressLogRepository;

    public ProgressService(IProgressLogRepository progressLogRepository)
    {
        _progressLogRepository = progressLogRepository;
    }
    
    public async Task<ProgressLog?> GetProgressForTodayAsync(Guid clientId)
    {
        return await _progressLogRepository.GetProgressLogForTodayAsync(clientId);
    }

    public async Task<Guid> LogProgressForTodayAsync(ProgressLog progressLog)
    {
        ProgressLog? existingLog = await _progressLogRepository.GetProgressLogForTodayAsync(progressLog.ClientId);
        if (existingLog != null)
        {
            existingLog.CaloriesLogged += progressLog.CaloriesLogged;
            await _progressLogRepository.UpdateProgressLogAsync(existingLog);
        }
        else
        {
            progressLog.Id = Guid.NewGuid();
            await _progressLogRepository.InsertProgressLogAsync(progressLog);
        }
        
        return progressLog.Id.GetValueOrDefault();
    }
}
