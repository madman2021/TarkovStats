using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TarkovStats.Middleware;
using TarkovStats.Repo;
using TarkovStats.Services;
using TarkovStats.Services.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables();
var connectionString = builder.Configuration.GetConnectionString("TarkovStatsContextConnection") ??
                       throw new InvalidOperationException(
                           "Connection string 'TarkovStatsContextConnection' not found.");
if (!string.IsNullOrWhiteSpace(builder.Configuration["key_store"]))
{
    builder.Services.AddDataProtection().PersistKeysToFileSystem(new DirectoryInfo(builder.Configuration["key_store"]));
}

builder.Services.AddDbContext<TarkovStatsContext>(options => options.UseSqlite(connectionString));
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<TarkovStatsContext>();

builder.Services.AddScoped<UserInfoHolder>();
builder.Services.AddScoped<UserInfo>(s => s.GetRequiredService<UserInfoHolder>().UserInfo);
builder.Services.AddScoped<IRaidService, RaidService>();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
});
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseMiddleware<UserInfoMiddleware>();
app.MapRazorPages();
HandleMigrations();
app.Run();

void HandleMigrations()
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<TarkovStatsContext>();
    db.Database.Migrate();
}