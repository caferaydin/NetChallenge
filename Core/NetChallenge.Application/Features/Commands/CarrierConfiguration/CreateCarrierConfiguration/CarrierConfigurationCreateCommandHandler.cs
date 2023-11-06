using MediatR;
using NetChallenge.Application.Abstractions.Repository.Write;
using NetChallenge.Application.Abstractions.Services;

namespace NetChallenge.Application.Features.Commands.CarrierConfiguration.CreateCarrierConfiguration
{
    public class CarrierConfigurationCreateCommandHandler : IRequestHandler<CarrierConfigurationCreateCommandRequest, CarrierConfigurationCreateCommandResponse>
    {
        #region Fields

        private readonly ICarrierConfigurationWriteRepository _carrierConfigurationWriteRepository;

        #endregion

        #region Ctor

        public CarrierConfigurationCreateCommandHandler(ICarrierConfigurationWriteRepository carrierConfigurationWriteRepository)
        {
            _carrierConfigurationWriteRepository = carrierConfigurationWriteRepository;
        }

        #endregion

        public async Task<CarrierConfigurationCreateCommandResponse> Handle(CarrierConfigurationCreateCommandRequest request, CancellationToken cancellationToken)
        {
            await _carrierConfigurationWriteRepository.AddAsync(new()
            {
                CarrierId = request.CarrierId,
                CarrierMinDesi = request.CarrierMinDesi,
                CarrierMaxDesi = request.CarrierMaxDesi,
                CarrierCost = request.CarrierCost,
            });

            await _carrierConfigurationWriteRepository.SaveAsync();

            return new()
            {
                Message = "New carrier configurations added",
            };
        }
    }
}
