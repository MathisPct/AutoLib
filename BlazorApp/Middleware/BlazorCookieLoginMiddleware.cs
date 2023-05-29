using BlazorApp.Models.Domain;
using Microsoft.AspNetCore.Identity;

namespace BlazorApp.Middleware;

public class BlazorCookieLoginMiddleware
{
    private readonly RequestDelegate _next;

    public BlazorCookieLoginMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public static Dictionary<Guid, LoginInfo> Logins { get; set; } = new Dictionary<Guid, LoginInfo>();

    public async Task Invoke(HttpContext httpContext, SignInManager<Client> signInManager, UserManager<Client> userManager)
    {
        if (httpContext.Request.Path.StartsWithSegments(new PathString("/login")) && httpContext.Request.Query.ContainsKey("key"))
        {
            Guid key = Guid.Parse(httpContext.Request.Query["key"]);
            if (Logins.TryGetValue(key, out LoginInfo login))
            {
                Logins.Remove(key);
                var user = await userManager.FindByEmailAsync(login.Email);
                await signInManager.SignInAsync(user, false);
                httpContext.Response.Redirect("/");
            }
        }

        await _next(httpContext);
    }
}

public class LoginInfo
{
    public string Email { get; set; }
    public string Password { get; set; }
}