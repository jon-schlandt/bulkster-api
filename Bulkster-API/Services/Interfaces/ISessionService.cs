namespace Bulkster_API.Services.Interfaces;

public interface ISessionService
{
    public Task<int> RefreshSessionAsync(Guid clientId);
}