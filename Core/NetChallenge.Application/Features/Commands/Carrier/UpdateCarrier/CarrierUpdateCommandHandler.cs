using MediatR;
using NetChallenge.Application.Abstractions.Repository.Read;
using NetChallenge.Application.Abstractions.Repository.Write;

namespace NetChallenge.Application.Features.Commands.Carrier.UpdateCarrier
{
    public class CarrierUpdateCommandHandler : IRequestHandler<CarrierUpdateCommandRequest, CarrierUpdateCommandResponse>
    {
        #region Fields
        private readonly IMediator _mediator;
        private readonly ICarrierReadRepository _carrierReadRepository;
        private readonly ICarrierWriteRepository _carrierWriteRepository;
        #endregion

        #region Ctor
        public CarrierUpdateCommandHandler(IMediator mediator, ICarrierReadRepository carrierReadRepository, ICarrierWriteRepository carrierWriteRepository)
        {
            _mediator = mediator;
            _carrierReadRepository = carrierReadRepository;
            _carrierWriteRepository = carrierWriteRepository;
        }
        #endregion

        #region Method
        public async Task<CarrierUpdateCommandResponse> Handle(CarrierUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Carrier carrier = await _carrierReadRepository.GetByIdAsync(request.Id);
            carrier.CarrierName = request.CarrierName;
            carrier.CarrierIsActive = request.CarrierIsActive;
            carrier.CarrierPlusDesiCost = request.CarrierPlusDesiCost;
            carrier.CarrierConfigurationId = request.CarrierConfigurationId;
            await _carrierWriteRepository.SaveAsync();

            return new()
            {
                Message = "Carrier information updated.",
            };
        }
        #endregion
    }
}
