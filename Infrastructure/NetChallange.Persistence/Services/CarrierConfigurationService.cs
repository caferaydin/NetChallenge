using Microsoft.EntityFrameworkCore;
using NetChallenge.Application.Abstractions.Repository.Read;
using NetChallenge.Application.Abstractions.Repository.Write;
using NetChallenge.Application.Abstractions.Services;
using NetChallenge.Application.ViewModel.CarrierConfiguration;
using NetChallenge.Domain.Entities;

namespace NetChallenge.Persistence.Services
{
    public class CarrierConfigurationService : ICarrierConfigurationService
    {
        #region Field
        private readonly ICarrierConfigurationReadRepository _readRepository;
        private readonly ICarrierConfigurationWriteRepository _writeRepository;
        #endregion

        #region Ctor
        public CarrierConfigurationService(ICarrierConfigurationReadRepository readRepository, ICarrierConfigurationWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }
        #endregion

        #region Method
        public async Task<string> CreateCarrierConfigurationAsync(CreateCarrierConfiguration createCarrierConfiguration)
        {
            var carrierConfiguration = new CarrierConfiguration
            {
                CarrierId = createCarrierConfiguration.CarrierId,
                CarrierMinDesi = createCarrierConfiguration.CarrierMinDesi,
                CarrierMaxDesi = createCarrierConfiguration.CarrierMaxDesi,
                CarrierCost = createCarrierConfiguration.CarrierCost
            };

            await _writeRepository.AddAsync(carrierConfiguration);
            await _writeRepository.SaveAsync();

            return "Yeni Konfigurasyon Eklendi: " + carrierConfiguration.Id;
        }

        public async Task<string> DeleteAsync(int id)
        {
            var entityToDelete = await _readRepository.GetByIdAsync(id);

            if (entityToDelete != null)
            {
                await _writeRepository.RemoveAsync(id);
                await _writeRepository.SaveAsync();

                return id + " id'li Kayıt Silindi.";
            }
            else
            {
                return "Belirtilen id'ye sahip kayıt bulunamadı veya silme işlemi sırasında bir hata oluştu.";
            }
        }

        public async Task<List<CarrierConfiguration>> GetAllCarrierConfigurationsAsync()
        {
            return await _readRepository.GetAll().ToListAsync();
        }
        public async Task<CarrierConfiguration> GetByIdAsync(int id)
        {
            return await _readRepository.GetByIdAsync(id);
        }

        public async Task<string> UpdateCarrierConfiguration(UpdateCarrierConfiguration updateCarrierConfiguration)
        {
            var carrierConfiguration = await _readRepository.GetByIdAsync(updateCarrierConfiguration.Id);

            if (carrierConfiguration != null)
            {
                carrierConfiguration.CarrierMinDesi = updateCarrierConfiguration.CarrierMinDesi;
                carrierConfiguration.CarrierMaxDesi = updateCarrierConfiguration.CarrierMaxDesi;
                carrierConfiguration.CarrierCost = updateCarrierConfiguration.CarrierCost;

                _writeRepository.Update(carrierConfiguration);
                await _writeRepository.SaveAsync();

                return carrierConfiguration.Id + "' li Kargo bilgileri güncellendi.";
            }
            else
            {
                return "Belirtilen id'ye sahip kayıt bulunamadı veya güncelleme işlemi sırasında bir hata oluştu.";
            }
        }

        #endregion
    }
}
