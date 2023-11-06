using MediatR;
using NetChallenge.Application.Abstractions.Repository.Write;

namespace NetChallenge.Application.Features.Commands.Carrier.CreateCarrier
{
    public class CarrierCreateCommandHandler : IRequestHandler<CarrierCreateCommandRequest, CarrierCreateCommandResponse>
    {
        #region Fields

        private readonly IMediator _mediator;
        private readonly ICarrierWriteRepository _carrierWriteRepository;

        #endregion

        #region Ctor

        public CarrierCreateCommandHandler(IMediator mediator, ICarrierWriteRepository carrierWriteRepository)
        {
            _mediator = mediator;
            _carrierWriteRepository = carrierWriteRepository;
        }

        #endregion

        #region Method 

        public async Task<CarrierCreateCommandResponse> Handle(CarrierCreateCommandRequest request, CancellationToken cancellationToken)
        {
            await _carrierWriteRepository.AddAsync(new()
            {
                CarrierPlusDesiCost = request.CarrierPlusDesiCost,
                CarrierConfigurationId = request.CarrierConfigurationId,
                CarrierName = request.CarrierName,
                CarrierIsActive = request.CarrierIsActive,
            });
            await _carrierWriteRepository.SaveAsync();

            return new()
            {
                Message = "New carrier created.",
            };

        }

        #endregion
    }
}
