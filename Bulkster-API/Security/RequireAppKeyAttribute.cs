using Microsoft.AspNetCore.Mvc;

namespace Bulkster_API.Security;

public class RequireAppKeyAttribute : ServiceFilterAttribute
{
    public RequireAppKeyAttribute() : base(typeof(ApiKeyAuthFilter))
    {
    }
}
