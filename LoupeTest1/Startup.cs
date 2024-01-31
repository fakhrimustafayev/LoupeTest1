using Microsoft.Extensions.DependencyInjection;
using System;
using Gibraltar.Agent;
using Loupe.Agent.Core.Services;
using Loupe.Agent.EntityFrameworkCore;
using Loupe.Agent.PerformanceCounters;
using Loupe.Extensions.Logging;

namespace GibraltarTest
{
    internal class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();


            // Adding a simple logging statement
            Console.WriteLine("Logging: ConfigureServices method is called.");
        }
    }
}