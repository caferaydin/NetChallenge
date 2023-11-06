using Microsoft.EntityFrameworkCore;
using NetChallenge.Application.Abstractions.Repository.Read;
using NetChallenge.Application.Abstractions.Repository.Write;
using NetChallenge.Application.Abstractions.Services;
using NetChallenge.Application.DTOs.Order;
using NetChallenge.Application.ViewModel.Order;
using NetChallenge.Domain.Entities;

namespace NetChallenge.Persistence.Services
{
    public class OrderService : IOrderService
    {
        #region field
        private readonly IOrderReadRepository _orderReadRepository;
        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly ICarrierConfigurationReadRepository _carrierConfigurationReadRepository;
        private readonly ICarrierConfigurationWriteRepository _carrierConfigurationWriteRepository;

        #endregion

        #region Ctor
        public OrderService(IOrderReadRepository orderReadRepository,
            IOrderWriteRepository orderWriteRepository,
            ICarrierConfigurationReadRepository carrierConfigurationReadRepository,
            ICarrierConfigurationWriteRepository carrierConfigurationWriteRepository
            )
        {
            _orderReadRepository = orderReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _carrierConfigurationReadRepository = carrierConfigurationReadRepository;
            _carrierConfigurationWriteRepository = carrierConfigurationWriteRepository;
        }
        #endregion

        #region Method
        public async Task<bool> DeleteAsync(int orderId)
        {
            var query = await _orderWriteRepository.RemoveAsync(orderId);
            _orderWriteRepository.SaveAsync();
            return query;
        }

        public async Task<List<OrderDTO>> GetAllOrdersAsync()
        {
            var orders  =await _orderReadRepository.GetAll().ToListAsync();
            //var orderlist = _mapper.Map<IQueryable<OrderList>>(orders);

            throw new NotImplementedException();
        }

        public async Task<OrderDTO> GetByIdAsync(int orderId)
        {
            var query =  await _orderReadRepository.GetByIdAsync(orderId);
            throw new NotImplementedException();
        }

        public async Task<string> CreateOrderAsync(CreateOrder createOrder)
        {
            int orderDesi = createOrder.OrderDesi;
            var bestCarrier = await _carrierConfigurationReadRepository
                .GetWhere(cf =>   orderDesi >= cf.CarrierMinDesi  
                            &&    orderDesi <= cf.CarrierMaxDesi )
                .ToListAsync();

            if (bestCarrier.Any())
            {

                var selectedCarrier = bestCarrier.OrderBy(cf => cf.CarrierCost).First();

                decimal totalCost = selectedCarrier.CarrierCost;

                await _orderWriteRepository.AddAsync(new Order
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
                    decimal extraDesiCost = notRange.CarrierCost * 1/8;

                    decimal totalCost = notRange.CarrierCost + (diff * extraDesiCost);

                    await _orderWriteRepository.AddAsync(new Order
                    {
                        CarrierId = notRange.CarrierId,
                        OrderCarrierCost = totalCost,
                        OrderDesi = createOrder.OrderDesi,
                        OrderDate = DateTime.Now
                    });
                    await _orderWriteRepository.SaveAsync();

                }
            }

            return "Sipariş Eklendi";
        }



        #endregion

    }
}
