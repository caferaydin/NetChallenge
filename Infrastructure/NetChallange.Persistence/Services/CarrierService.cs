using Microsoft.EntityFrameworkCore;
using NetChallenge.Application.Abstractions.Repository.Read;
using NetChallenge.Application.Abstractions.Repository.Write;
using NetChallenge.Application.Abstractions.Services;
using NetChallenge.Application.DTOs.Carrier;
using NetChallenge.Application.DTOs.Order;
using NetChallenge.Application.ViewModel.Carrier;

namespace NetChallenge.Persistence.Services
{
    public class CarrierService : ICarrierService
    {
        #region Field 
        private readonly ICarrierReadRepository _readRepository;
        private readonly ICarrierWriteRepository _writeRepository;
        #endregion

        #region Ctor
        public CarrierService(ICarrierReadRepository readRepository, ICarrierWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }
        #endregion

        #region Method
        public async Task CreateCarrierAsync(CreateOrderDTO createCarrier)
        {
            await _writeRepository.AddAsync(new()
            {
                CarrierName = createCarrier.CarrierName,
                CarrierIsActive = createCarrier.CarrierIsActive,
                CarrierConfigurationId = createCarrier.CarrierConfigurationId,
                CarrierPlusDesiCost = createCarrier.CarrierPlusDesiCost,
            }); 
            await _writeRepository.SaveAsync();

            //Carrier carrier = new()
            //{
            //    CarrierName = createCarrier.CarrierName,
            //    CarrierIsActive = true,
            //    CarrierPlusDesiCost = createCarrier.CarrierPlusDesiCost,
            //    CarrierConfigurationId = createCarrier.CarrierConfigurationId,
            //};
            //await _writeRepository.AddAsync(carrier);
            //await _writeRepository.SaveAsync();


        }

        public async Task<bool> DeleteAsync(int carrierId)
        {
            await _writeRepository.RemoveAsync(carrierId);
            await _writeRepository.SaveAsync();
            return true;
        }

        public async Task<List<CarrierDTO>> GetAllCarriersAsync()
        {
            var carrier =  await _readRepository.GetAll().ToListAsync();

            throw new NotImplementedException();
        }

        public async Task<CarrierDTO> GetByIdAsync(int Id)
        {
            var query =  await _readRepository.GetByIdAsync(Id);
            throw new NotImplementedException();
        }

        public async Task<string> UpdateCarrier(UpdateCarrier updateCarrier)
        {
            var carrier = await _readRepository.GetByIdAsync(updateCarrier.Id);

            if (carrier != null)
            {
                carrier.CarrierName = updateCarrier.CarrierName;
                carrier.CarrierIsActive = updateCarrier.CarrierIsActive;
                carrier.CarrierConfigurationId = updateCarrier.CarrierConfigurationId;
                carrier.CarrierPlusDesiCost = updateCarrier.CarrierPlusDesiCost;
                
                _writeRepository.Update(carrier);
                await _writeRepository.SaveAsync();

                return "Taşıyıcı bilgileri Güncellendi";
            }
            else
            {
                return null;
            }
        }

        #endregion
    }
}
