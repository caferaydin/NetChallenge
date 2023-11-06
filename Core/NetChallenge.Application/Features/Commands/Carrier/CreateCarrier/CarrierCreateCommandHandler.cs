using MediatR;
using NetChallenge.Application.Abstractions.Services;

namespace NetChallenge.Application.Features.Commands.Carrier.CreateCarrier
{
    public class CarrierCreateCommandHandler : IRequestHandler<CarrierCreateCommandRequest, CarrierCreateCommandResponse>
    {
        #region Fields

        private readonly IMediator _mediator;
        private readonly ICarrierService _carrierService;

        #endregion

        #region Ctor

        public CarrierCreateCommandHandler(IMediator mediator, ICarrierService carrierService)
        {
            _mediator = mediator;
            _carrierService = carrierService;
        }

        #endregion

        #region Method 

        public async Task<CarrierCreateCommandResponse> Handle(CarrierCreateCommandRequest request, CancellationToken cancellationToken)
        {
            await _carrierService.CreateCarrierAsync(new()
            {
                CarrierPlusDesiCost = request.CarrierPlusDesiCost,
                CarrierConfigurationId = request.CarrierConfigurationId,
                CarrierName = request.CarrierName,
                CarrierIsActive = request.CarrierIsActive,
            });

            return new()
            {
                Message = "New carrier created.",
            };

        }

        #endregion
    }
}
