using Microsoft.AspNetCore.SignalR;
using NetChallenge.Application.Abstractions.Hubs;
using NetChallenge.SignalR.Hubs;

namespace NetChallenge.SignalR.HubsServices
{
    public class OrderHubService : IOrderHubService
    {
        private readonly IHubContext<OrderHub> _hubContext;

        public OrderHubService(IHubContext<OrderHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task OrderAddMessage(string message)
            => await _hubContext.Clients.All.SendAsync(ReceiveFunctionNames.OrderAddedMessage, message);
    }
}
