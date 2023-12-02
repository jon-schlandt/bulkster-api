namespace Bulkster_API.Security;

public interface IApiKeyValidator
{
    bool IsValidApiKey(string apiKey);
}
