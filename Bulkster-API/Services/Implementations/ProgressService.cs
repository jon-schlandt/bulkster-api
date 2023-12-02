using Bulkster_API.Data;
using Bulkster_API.Models.Service;
using Bulkster_API.Repositories.Interfaces;
using Bulkster_API.Services.Interfaces;

namespace Bulkster_API.Services.Implementations;

public class ProgressService : IProgressService
{
    private readonly IProgressLogRepository _progressLogRepository;
    private readonly IBulksterDbContext _dbContext;

    public ProgressService(IProgressLogRepository progressLogRepository, IBulksterDbContext dbContext)
    {
        _progressLogRepository = progressLogRepository;
        _dbContext = dbContext;
    }
    
    public async Task<ProgressLog?> GetProgressForToday(Guid clientId)
    {
        return await _progressLogRepository.GetProgressLogForToday(clientId);
    }

    public async Task<Guid> LogProgressForToday(ProgressLog progressLog)
    {
        ProgressLog? existingLog = await _progressLogRepository.GetProgressLogForToday(progressLog.ClientId);
        if (existingLog != null)
        {
            progressLog.Id = existingLog.Id;
            _dbContext.ProgressLog.Update(progressLog.ToRepositoryModel());
        }
        else
        {
            progressLog.Id = Guid.NewGuid();
            _dbContext.ProgressLog.Add(progressLog.ToRepositoryModel());
        }
        
        await _dbContext.SaveChangesAsync();
        return progressLog.Id;
    }
}
