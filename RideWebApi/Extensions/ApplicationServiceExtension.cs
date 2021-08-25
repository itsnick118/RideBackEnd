using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RideApi.Services;
using RideWebApi.Data;
using RideWebApi.Helpers;
using RideWebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RideWebApi.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            // services.AddDbContext<RideWebApi.Models.RideContext>();
            services.AddDbContext<RideContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")
                    , sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure();
                    }
                    );
            });
            return services;
        }
    }
}
