using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VeloWorldSystem.Data;
using VeloWorldSystem.Mapping;
using VeloWorldSystem.Models.Entities.Identity;
using VeloWorldSystem.Services;
using VeloWorldSystem.Services.Contracts;
using VeloWorldSystem.Services.Models;
using VeloWorldSystem.Web.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("VeloWorldSystemConnection");
builder.Services
    .AddDbContext<VeloWorldSystemDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services
    .AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
    .AddRoles<ApplicationRole>()
    .AddEntityFrameworkStores<VeloWorldSystemDbContext>();
builder.Services.AddControllersWithViews();

// Application services
builder.Services.AddScoped<IDemoService, DemoService>();

var app = builder.Build();

AutoMapperConfig.RegisterMappings(
    typeof(ErrorViewModel).GetTypeInfo().Assembly,
    typeof(DemoDto).GetTypeInfo().Assembly);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
