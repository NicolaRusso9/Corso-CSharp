using CorsoCSharp.EFCore.AutoGenModels;
using Microsoft.EntityFrameworkCore;

namespace PraticalApps
{
    // separazione della configurazione dal file program.cs
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();       // aggiunge le razor pages

            services.AddDbContext<NorthwindContext>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsDevelopment())
            {
                app.UseHsts();
            }

            app.UseRouting();   // start endpoint routing
            app.UseHttpsRedirection();

            app.UseDefaultFiles();  // index.html, default.html and so on
            app.UseStaticFiles();   // wwroot files and all static file like css, html etc

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();      // mappa le razor pages
                endpoints.MapGet("/hello", () => "Hello world!");
            });
        }
    }
}
