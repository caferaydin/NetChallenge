using NetChallenge.Application.DTOs.Carrier;
using NetChallenge.Application.DTOs.Order;

namespace NetChallenge.Application.Abstractions.Services
{
    public interface ICarrierService
    {
        Task<List<CarrierCreateDTO>> GetAllCarriersAsync();
        Task<CarrierCreateDTO> GetByIdAsync(int Id);
        Task CreateCarrierAsync(CarrierCreateDTO request);
        


    }
}
