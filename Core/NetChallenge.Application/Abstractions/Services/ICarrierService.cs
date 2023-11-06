using NetChallenge.Application.DTOs.Carrier;
using NetChallenge.Application.DTOs.Order;

namespace NetChallenge.Application.Abstractions.Services
{
    public interface ICarrierService
    {
        Task<List<CarrierDTO>> GetAllCarriersAsync();
        Task<CarrierDTO> GetByIdAsync(int Id);
        Task CreateCarrierAsync(CreateOrderDTO request);
        


    }
}
