using Microsoft.AspNetCore.Http;

namespace Common.Security;

public class AuthenticatedUser
{
    public string Id { get; private set; } = "3540bae1-079d-43a3-b0d8-13ffff9dc782";

    public AuthenticatedUser(IHttpContextAccessor httpContext)
    {
        // var user = httpContext.HttpContext.User;
        // Id = user.Claims.First(c => c.Type == "http://schemas.microsoft.com/identity/claims/objectidentifier").Value;
    }
}
