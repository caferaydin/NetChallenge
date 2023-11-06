using Microsoft.Extensions.DependencyInjection;
using NetChallenge.Application.Abstractions.Hubs;
using NetChallenge.SignalR.HubsServices;

namespace NetChallenge.SignalR
{
    public static class ServiceRegistration
    {
        public static void AddSignalRServices(this IServiceCollection collection)
        {
            collection.AddTransient<IOrderHubService, OrderHubService>();
        }
    }
}
