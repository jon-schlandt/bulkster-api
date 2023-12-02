namespace Bulkster_API.Security;

public class ApiKeyValidator : IApiKeyValidator
{
    private readonly IConfiguration _configuration;
    
    public ApiKeyValidator(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public bool IsValidApiKey(string userApiKey)
    {
        if (string.IsNullOrWhiteSpace(userApiKey))
        {
            return false;
        }

        var apiKey = _configuration.GetValue<string>("ApiKey");
        return apiKey != null && apiKey == userApiKey;
    }
}
