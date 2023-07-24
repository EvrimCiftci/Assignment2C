using Evrim_Assignment2; // Include the namespace of your project

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

public class Program
{
    public static void Main(string[] args)
    {
        // Create and build the host for the web application
        CreateHostBuilder(args).Build().Run();
    }

    // Define the host builder method
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args) // Create a default host builder with common configuration
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>(); // Use the Startup class to configure the web application
            });
}

