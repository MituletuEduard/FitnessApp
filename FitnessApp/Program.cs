using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FitnessApp.Services;
using FitnessApp.Models;
using FitnessApp.Services.Timer;  // Adjust the namespace as necessary

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddScoped<ITimerRepository, TimerRepository>();
builder.Services.AddScoped<ITimerService, TimerService>();


builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FitnessDb")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationContext>();

// Register the custom logging service
builder.Services.AddSingleton<ILog, MyConsoleLogger>();

// Register repositories and services
builder.Services.AddScoped<IMasuratoriRepository, MasuratoriRepository>();
builder.Services.AddScoped<IMasuratoriService, MasuratoriService>();

// Configure Facebook authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
    options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();  // Ensure authentication middleware is used
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers(); // Add this line to map controllers

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
