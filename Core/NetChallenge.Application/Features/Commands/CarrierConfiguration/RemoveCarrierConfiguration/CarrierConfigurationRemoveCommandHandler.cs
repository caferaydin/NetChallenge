using MediatR;
using NetChallenge.Application.Abstractions.Repository.Write;

namespace NetChallenge.Application.Features.Commands.CarrierConfiguration.RemoveCarrierConfiguration
{
    public class CarrierConfigurationRemoveCommandHandler : IRequestHandler<CarrierConfigurationRemoveCommandRequest, CarrierConfigurationRemoveCommandResponse>
    {
        #region Fields

        private readonly ICarrierConfigurationWriteRepository _carrierConfigurationWriteRepository;

        #endregion
        
        #region Ctor
        public CarrierConfigurationRemoveCommandHandler(ICarrierConfigurationWriteRepository carrierConfigurationWriteRepository)
        {
            _carrierConfigurationWriteRepository = carrierConfigurationWriteRepository;
        }

        #endregion
        public async Task<CarrierConfigurationRemoveCommandResponse> Handle(CarrierConfigurationRemoveCommandRequest request, CancellationToken cancellationToken)
        {
            await _carrierConfigurationWriteRepository.RemoveAsync(request.Id);
            await _carrierConfigurationWriteRepository.SaveAsync();
            return new()
            {
                Message = request.Id + " Configuration is Deleted.",
            };
        }
    }
}
