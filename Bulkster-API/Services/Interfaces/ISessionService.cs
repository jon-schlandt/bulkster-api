namespace Bulkster_API.Services.Interfaces;

public interface ISessionService
{
    public Task<Guid> RefreshSessionAsync(Guid clientId);
}