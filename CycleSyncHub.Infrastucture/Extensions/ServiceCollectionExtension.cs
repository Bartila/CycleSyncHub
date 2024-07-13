using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CycleSyncHub.Domain.Interfaces;
using CycleSyncHub.Infrastucture.Persistence;
using CycleSyncHub.Infrastucture.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CycleSyncHub.Infrastucture.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CycleSyncHubDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("CycleSyncHub")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<CycleSyncHubDbContext>(); //from documentation

           /* services.AddScoped<BikeSeeder>();*/

            services.AddScoped<IBikeRepository, BikeRepository>();
            services.AddScoped<IBikeInfoRepository, BikeInfoRepository>();
        }
    }
}
