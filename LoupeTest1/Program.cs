

using System;
using Gibraltar.Agent;
using Loupe.Agent.AspNetCore;
using Loupe.Agent.Core.Services;
using Loupe.Agent.EntityFrameworkCore;
using Loupe.Agent.PerformanceCounters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GibraltarTest;

class Program
{
    public static void Main(string[] args)
    {
        try
        {
            CreateHostBuilder(args).Build().Run();
        }
        catch (Exception ex)
        {
            // Log the exception
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .AddLoupe(builder => builder.AddAspNetCoreDiagnostics()
                .AddClientLogging()                     // The Loupe endpoint for client logging
                .AddEntityFrameworkCoreDiagnostics()    // EF Core monitoring
                .AddPerformanceCounters())              // Windows Perf Counter monitoring
            .ConfigureServices((hostContext, services) =>
            {
                // Log an informational message
                var logger = services.BuildServiceProvider().GetService<ILogger<Program>>();
                logger.LogInformation("Application starting up...");
            });
}

