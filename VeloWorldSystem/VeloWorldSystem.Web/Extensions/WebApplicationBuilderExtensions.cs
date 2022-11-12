namespace VeloWorldSystem.Web.Extensions
{
    using CloudinaryDotNet;
    using VeloWorldSystem.Data;
    using VeloWorldSystem.GpxProcessing;
    using VeloWorldSystem.Models.Entities.Identity;
    using VeloWorldSystem.Services.Libraries.Contracts;
    using VeloWorldSystem.Services.Libraries;
    using Microsoft.EntityFrameworkCore;
    using VeloWorldSystem.Services.Contracts;
    using VeloWorldSystem.Services.Services;
    using Microsoft.AspNetCore.Hosting;
    using VeloWorldSystem.DtoModels;
    using System.Reflection;
    using VeloWorldSystem.Mapping;
    using VeloWorldSystem.Data.Contracts;
    using TestTemplate.Data.Repositories;
    using VeloWorldSystem.Data.Repositories;

    public static class WebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder AddDbContext(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("VeloWorldSystemConnection");
            builder.Services
                .AddDbContext<VeloWorldSystemDbContext>(options => 
                {
                    options.UseSqlServer(connectionString);
                });

            return builder;
        }

        public static WebApplicationBuilder AddDatabaseDeveloperPageExceptionFilter(this WebApplicationBuilder builder)
        {
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            return builder;
        }

        public static WebApplicationBuilder AddIdentity(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequiredLength = 6;
                    options.User.RequireUniqueEmail = true;
                })
                .AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<VeloWorldSystemDbContext>();

            return builder;
        }

        public static WebApplicationBuilder AddControllersWithViews(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllersWithViews();
            return builder;
        }

        public static WebApplicationBuilder AddCloudinary(this WebApplicationBuilder builder)
        {
            var cloudinaryCredentials = new Account(
                builder.Configuration["Cloudinary:CloudName"],
                builder.Configuration["Cloudinary:ApiKey"],
                builder.Configuration["Cloudinary:ApiSecret"]);
            var cloudinary = new Cloudinary(cloudinaryCredentials);
            builder.Services.AddSingleton(cloudinary);
            return builder;
        }

        public static WebApplicationBuilder AddApplicationServices(this WebApplicationBuilder builder)
        {
            // Cloud and external libraries
            builder.Services.AddScoped<IGpxService, GpxService>();
            builder.Services.AddScoped<ICloudinaryService, CloudinaryService>();

            // Repositories
            builder.Services.AddScoped(typeof(IDeletableRepository<>), typeof(DeletableRepository<>));
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Entities
            builder.Services.AddScoped<IBikeTypeService, BikeTypeService>();
            return builder;
        }
    }
}
