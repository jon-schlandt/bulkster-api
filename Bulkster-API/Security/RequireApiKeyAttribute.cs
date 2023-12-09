using Microsoft.AspNetCore.Mvc;

namespace Bulkster_API.Security;

public class RequireApiKeyAttribute : ServiceFilterAttribute
{
    public RequireApiKeyAttribute() : base(typeof(ApiKeyAuthFilter))
    {
    }
}
