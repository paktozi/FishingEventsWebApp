using FishingEvents.Infrastructure.Data.Models;
using FishingEventsApp.Core.Contracts;
using FishingEventsApp.Core.Services;
using FishingEventsApp.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class FishingEventCollectionExtension
    {
        public static IServiceCollection AddAppDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            services.AddDbContext<FishingEventsDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }

        public static IServiceCollection AddAppIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
              .AddRoles<IdentityRole>()
              .AddEntityFrameworkStores<FishingEventsDbContext>()
              .AddDefaultTokenProviders();

            return services;
        }

        public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IFishingEventService, FishingEventService>();
            services.AddScoped<IApplicationUserService, ApplicationUserService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<ISpeciesService, SpeciesService>();
            services.AddScoped<IFishCaughtService, FishCaughtService>();
            services.AddScoped<ILeaderBoardService, LeaderBoardService>();
            services.AddHttpClient<WeatherService>();
            services.AddScoped<IUserRoleService, UserRoleService>();

            return services;
        }
    }
}
