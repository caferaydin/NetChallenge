using NetChallenge.Application.ViewModel.CarrierConfiguration;
using NetChallenge.Domain.Entities;

namespace NetChallenge.Application.Abstractions.Services
{
    public interface ICarrierConfigurationService
    {
        Task<List<CarrierConfiguration>> GetAllCarrierConfigurationsAsync();
        Task<CarrierConfiguration> GetByIdAsync(int Id);
        Task<string> CreateCarrierConfigurationAsync(CreateCarrierConfiguration createCarrierConfiguration);
        Task<string> UpdateCarrierConfiguration(UpdateCarrierConfiguration updateCarrierConfiguration);
        Task<string> DeleteAsync(int id);
    }
}
