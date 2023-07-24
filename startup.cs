using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace Evrim_Assignment2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration; // Constructor: Initializes the configuration object
        }

        public IConfiguration Configuration { get; } // Property to access configuration settings

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthorization(); // Add the required authorization services (if needed)

            // Configure the servicee class as a singleton
            services.AddSingleton<servicee>(provider =>
            {
                var webHostEnvironment = provider.GetRequiredService<IWebHostEnvironment>();
                var filePath = Path.Combine(webHostEnvironment.WebRootPath, "data", "YourJSONfileName.json");
                return new servicee(filePath);
            });

            services.AddRazorPages(); // Add Razor Pages service to the container
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // Use detailed error page during development
            }
            else
            {
                app.UseExceptionHandler("/Error"); // Handle errors with a custom error page
                app.UseHsts(); // Enable HTTP Strict Transport Security (HSTS) for added security
            }

            app.UseHttpsRedirection(); // Redirect HTTP requests to HTTPS
            app.UseStaticFiles(); // Serve static files (e.g., CSS, JavaScript, images)

            app.UseRouting(); // Enable routing middleware for the application

            app.UseAuthorization(); // Use authorization middleware for security (if needed)

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages(); // Map Razor Pages endpoints
            });
        }
    }
}
