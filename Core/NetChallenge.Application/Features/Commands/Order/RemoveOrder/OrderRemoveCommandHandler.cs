using MediatR;
using NetChallenge.Application.Abstractions.Repository.Write;

namespace NetChallenge.Application.Features.Commands.Order.RemoveOrder
{
    public class OrderRemoveCommandHandler : IRequestHandler<OrderRemoveCommandRequest, OrderRemoveCommandResponse>
    {
        private readonly IOrderWriteRepository _orderWriteRepository;

        public OrderRemoveCommandHandler(IOrderWriteRepository orderWriteRepository)
        {
            _orderWriteRepository = orderWriteRepository;
        }

        public async Task<OrderRemoveCommandResponse> Handle(OrderRemoveCommandRequest request, CancellationToken cancellationToken)
        {
            await _orderWriteRepository.RemoveAsync(request.Id);
            await _orderWriteRepository.SaveAsync();

            return new()
            {
                Message = request.Id + " Kayıt Silindi",
            };
        }
    }
}
