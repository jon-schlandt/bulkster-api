using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Bulkster_API.Security;

public class ApiKeyAuthFilter : IAuthorizationFilter
{
    private readonly IApiKeyValidator _apiKeyValidation;
    public ApiKeyAuthFilter(IApiKeyValidator apiKeyValidation)
    {
        _apiKeyValidation = apiKeyValidation;
    }
    
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var apiKey = context.HttpContext.Request.Headers["ApiKey"].ToString();
        if (string.IsNullOrWhiteSpace(apiKey))
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        if (!_apiKeyValidation.IsValidApiKey(apiKey))
        {
            context.Result = new UnauthorizedResult();
        }
    }
}
