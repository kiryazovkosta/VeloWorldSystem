using Microsoft.AspNetCore.Hosting;
using VeloWorldSystem.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder
    .AddDbContext()
    .AddDatabaseDeveloperPageExceptionFilter()
    .AddIdentity()
    .AddControllersWithViews()
    .AddCloudinary()
    .AddSendGrid()
    .AddApplicationServices();

var app = builder.Build();
app
    .UseAutoMapper()
    .UseEnvironment()
    .UseHttpsRedirection()
    .UseStaticFiles()
    .UseRouting()
    .UseAuthentication()
    .UseAuthorization()
    .UseEndPoints();

app.Run();
