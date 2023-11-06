using MediatR;
using Microsoft.EntityFrameworkCore;
using NetChallenge.Application.Abstractions.Repository.Read;
using NetChallenge.Application.Abstractions.Repository.Write;

namespace NetChallenge.Application.Features.Commands.Order.CreateOrder
{
    public class OrderCreateCommandHandler : IRequestHandler<OrderCreateCommandRequest, OrderCreateCommandResponse>
    {
        
        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly ICarrierConfigurationReadRepository _carrierConfigurationReadRepository;

        public OrderCreateCommandHandler(IOrderWriteRepository orderWriteRepository, ICarrierConfigurationReadRepository carrierConfigurationReadRepository)
        {
            _orderWriteRepository = orderWriteRepository;
            _carrierConfigurationReadRepository = carrierConfigurationReadRepository;
        }

        public async Task<OrderCreateCommandResponse> Handle(OrderCreateCommandRequest createOrder, CancellationToken cancellationToken)
        {
            int orderDesi = createOrder.OrderDesi;
            var bestCarrier = await _carrierConfigurationReadRepository
                .GetWhere(cf => orderDesi >= cf.CarrierMinDesi
                            && orderDesi <= cf.CarrierMaxDesi)
                .OrderByDescending(cf => cf.CarrierCost)
                .ToListAsync();

            if (bestCarrier.Any())
            {

                var selectedCarrier = bestCarrier.OrderBy(cf => cf.CarrierCost).First();

                decimal totalCost = selectedCarrier.CarrierCost;

                await _orderWriteRepository.AddAsync(new()
                {
                    CarrierId = selectedCarrier.CarrierId,
                    OrderCarrierCost = totalCost,
                    OrderDesi = createOrder.OrderDesi,
                    OrderDate = DateTime.Now
                });
                await _orderWriteRepository.SaveAsync();

            }
            else
            {

                var notRange = await _carrierConfigurationReadRepository
                    .GetWhere(cf => cf.CarrierMinDesi <= createOrder.OrderDesi)
                    .OrderBy(cf => Math.Abs(cf.CarrierMinDesi - createOrder.OrderDesi))
                .FirstOrDefaultAsync();

                if (bestCarrier != null)
                {

                    int diff = createOrder.OrderDesi - notRange.CarrierMaxDesi;
                    decimal extraDesiCost = notRange.CarrierCost * 1 / 8;

                    decimal totalCost = notRange.CarrierCost + (diff * extraDesiCost);

                    await _orderWriteRepository.AddAsync(new()
                    {
                        CarrierId = notRange.CarrierId,
                        OrderCarrierCost = totalCost,
                        OrderDesi = createOrder.OrderDesi,
                        OrderDate = DateTime.Now
                    });
                    await _orderWriteRepository.SaveAsync();

                }
            }

            return new()
            {
                Message = "Sipariş Oluşturuldu.",
            };
        }

    }
}
