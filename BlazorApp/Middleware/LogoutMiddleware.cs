using System.Text.Json.Serialization;
using BlazorApp.Models.Domain;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace BlazorApp.Middleware;

public class LogoutMiddleware
{
    private readonly RequestDelegate _next;

    public LogoutMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    
    public async Task InvokeAsync(HttpContext context, SignInManager<Client> signInManager)
    {
        if (context.Request.Path == "/logout")
        {
            await signInManager.SignOutAsync();
            context.Response.Redirect("/");
        }
        else
        {
            await _next(context);
        }
    }
}