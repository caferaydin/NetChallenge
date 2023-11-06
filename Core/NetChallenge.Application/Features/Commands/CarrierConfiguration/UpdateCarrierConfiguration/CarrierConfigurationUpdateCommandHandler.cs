using MediatR;
using NetChallenge.Application.Abstractions.Repository.Read;
using NetChallenge.Application.Abstractions.Repository.Write;

namespace NetChallenge.Application.Features.Commands.CarrierConfiguration.UpdateCarrierConfiguration
{
    public class CarrierConfigurationUpdateCommandHandler : IRequestHandler<CarrierConfigurationUpdateCommandRequest, CarrierConfigurationUpdateCommandResponse>
    {
        #region Fields

        private readonly ICarrierConfigurationReadRepository _carrierConfigurationReadRepository;
        private readonly ICarrierConfigurationWriteRepository _carrierConfigurationWriteRepository;

        #endregion

        #region Ctor

        public CarrierConfigurationUpdateCommandHandler(ICarrierConfigurationReadRepository carrierConfigurationReadRepository, ICarrierConfigurationWriteRepository carrierConfigurationWriteRepository)
        {
            _carrierConfigurationReadRepository = carrierConfigurationReadRepository;
            _carrierConfigurationWriteRepository = carrierConfigurationWriteRepository;
        }

        #endregion

        public async Task<CarrierConfigurationUpdateCommandResponse> Handle(CarrierConfigurationUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            //var carrierConfiguration = await _carrierConfigurationReadRepository.GetByIdAsync(request.Id);

            //carrierConfiguration.CarrierMinDesi = request.CarrierMinDesi;
            //carrierConfiguration.CarrierMaxDesi = request.CarrierMaxdesi;
            //carrierConfiguration.CarrierCost = request.CarrierCost;
            //await _carrierConfigurationWriteRepository.SaveAsync();

            //return new()
            //{
            //    Message = "Carrier Configuration is Updated"
            //};

            var carrierConfiguration = await _carrierConfigurationReadRepository.GetByIdAsync(request.Id);
            carrierConfiguration.CarrierMinDesi = request.CarrierMinDesi;
            carrierConfiguration.CarrierMaxDesi = request.CarrierMaxdesi;
            carrierConfiguration.CarrierCost = request.CarrierCost;
            await _carrierConfigurationWriteRepository.SaveAsync();

            return new()
            {
                Message = "Carrier Configuration is Updated.",
            };
        }
    }
}
