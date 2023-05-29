using BlazorApp.Middleware;
using BlazorApp.Models.Domain;
using BlazorApp.Repository;
using BlazorApp.Services;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<AutolibContext>();
builder.Services.AddSingleton<StationRepository>();
builder.Services.AddSingleton<StationService>();
builder.Services.AddSingleton<VehiculeRepository>();
builder.Services.AddSingleton<VehiculeService>();
builder.Services.AddSingleton<ReservationRepository>();
builder.Services.AddSingleton<ReservationService>();

builder.Services.AddIdentity<Client, IdentityRole>()
    .AddEntityFrameworkStores<AutolibContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<BlazorCookieLoginMiddleware>();
app.UseMiddleware<LogoutMiddleware>();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();