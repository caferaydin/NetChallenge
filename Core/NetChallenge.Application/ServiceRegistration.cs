using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace NetChallenge.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServiceRegistration));
        }
    }
}
