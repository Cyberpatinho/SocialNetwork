using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Net.NetworkInformation;

namespace WebApi.Extensions
{
    public class DbInitializer
    {
        public static async Task Initialize(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            try
            {
                var context = scope.ServiceProvider.GetService<ActivityContext>();

                await context.Database.MigrateAsync();
                await Seed.SeedData(context);
            }
            catch (Exception ex)
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error ocurred during db initialization.");
            }
        }
    }
}
