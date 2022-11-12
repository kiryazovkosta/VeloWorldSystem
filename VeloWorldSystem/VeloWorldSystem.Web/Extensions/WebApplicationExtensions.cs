using System.Reflection;
using VeloWorldSystem.DtoModels;
using VeloWorldSystem.Mapping;

namespace VeloWorldSystem.Web.Extensions
{
    public static class WebApplicationExtensions
    {
        public static WebApplication UseEnvironment(this WebApplication app)
        {

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/Error/{0}");
            return app;
        }

        public static IApplicationBuilder UseEndPoints(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("areaRoute", "{area:exists}/{controller=BikeTypes}/{action=All}/{id?}");
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            return app;
        }

        public static WebApplication UseAutoMapper(this WebApplication builder)
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);
            return builder;
        }
    }
}
