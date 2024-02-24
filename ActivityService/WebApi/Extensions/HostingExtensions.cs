using Application.Activities.Commands;
using Application.Activities.Queries;
using Application.Helpers;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace WebApi.Extensions
{
    public static class HostingExtensions
    {
        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
                });
            });

            builder.Services.AddDbContext<ActivityContext>(opt =>
            {
                opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);

            builder.Services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(typeof(GetActivities.Handler).Assembly);
            });

            return builder;
        }

        public static async Task<WebApplication> ConfigureApplication(this WebApplication app)
        {

            await DbInitializer.Initialize(app);

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.MapControllers();

            return app;
        }
    }
}
