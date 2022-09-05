using Microsoft.AspNetCore.Http;

namespace Common.Security;

public class AuthenticatedUser
{
    public string Id { get; private set; }

    public AuthenticatedUser(IHttpContextAccessor httpContext)
    {
        var user = httpContext.HttpContext.User;
        Id = user.Claims.First(c => c.Type == "http://schemas.microsoft.com/identity/claims/objectidentifier").Value;
    }
}
