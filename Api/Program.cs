using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Wbc.Infrastructure.Persistence;

namespace Wbc.Api
{
    public class Program
    {
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }

        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;

                    try
                        {
                            ////var context = services.GetRequiredService<ApplicationDbContext>();

                            ////if (context.Database.IsSqlServer()) context.Database.Migrate();

                            ////await ApplicationDbContextSeed.SeedSampleDataAsync(context);
                        }

                    catch (Exception ex)
                        {
                            var logger = scope.ServiceProvider.GetRequiredService<ILogger>();

                            logger.LogError(ex, "An error occurred while migrating or seeding the database.");

                            throw;
                        }
                }

            await host.RunAsync();
        }
    }
}
