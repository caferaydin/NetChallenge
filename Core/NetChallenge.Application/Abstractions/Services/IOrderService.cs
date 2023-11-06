
using NetChallenge.Application.DTOs.Order;
using NetChallenge.Application.ViewModel.Order;

namespace NetChallenge.Application.Abstractions.Services
{
    public interface IOrderService
    {
        Task<OrderDTO> GetByIdAsync(int orderId);
        Task<List<OrderDTO>> GetAllOrdersAsync();
        Task<string> CreateOrderAsync(CreateOrder createOrder);
        Task<bool> DeleteAsync(int orderId);

    }
}
