using Application.Services.Commands;
using Application.Services.Queries;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using global::MediatR;

namespace WebApplication1.Configurations
{
    internal static class MediatRConfig
    {
        internal static IServiceCollection ConfigureMediatR(this IServiceCollection services)
        {
            //Configure the mediator
            services.AddMediatR(typeof(AddTimeToProjectCommandHandler).Assembly,
                typeof(GetProjectTimeInformationsQueryHandler).Assembly,
                typeof(CreateProjectCommandHandler).Assembly );

            return services;
        }
    }
}
