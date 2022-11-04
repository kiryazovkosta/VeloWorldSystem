using VeloWorldSystem.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder
    .AddDbContext()
    .AddDatabaseDeveloperPageExceptionFilter()
    .AddIdentity()
    .AddControllersWithViews()
    .AddCloudinary()
    .AddApplicationServices();

var app = builder.Build();
app.UseEnvironment()
    .UseHttpsRedirection()
    .UseStaticFiles()
    .UseRouting()
    .UseAuthentication()
    .UseAuthorization()
    .MapEndPoints();
app.Run();
