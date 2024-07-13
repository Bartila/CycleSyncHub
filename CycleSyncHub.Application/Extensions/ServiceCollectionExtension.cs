using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CycleSyncHub.Application.ApplicationUser;
using CycleSyncHub.Application.Bike.Commands.CreateBike;
using CycleSyncHub.Application.Commands.CreateBike;
using CycleSyncHub.Application.Mappings;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CycleSyncHub.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
            public static void AddApplication(this IServiceCollection services)
            {
                services.AddScoped<IUserContext, UserContext>();

                services.AddMediatR(typeof(CreateBikeCommand));

            services.AddScoped(provider => new MapperConfiguration(cfg =>
            {
                var scope = provider.CreateScope();
                var userContext = scope.ServiceProvider.GetRequiredService<IUserContext>();
                cfg.AddProfile(new BikeMappingProfile(userContext));
            }).CreateMapper()
            );

                services.AddValidatorsFromAssemblyContaining<CreateBikeCommandValidator>()
                    .AddFluentValidationAutoValidation()
                    .AddFluentValidationClientsideAdapters();
            }
    }
}
