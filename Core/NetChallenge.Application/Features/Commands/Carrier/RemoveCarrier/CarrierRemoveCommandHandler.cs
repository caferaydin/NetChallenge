using MediatR;
using NetChallenge.Application.Abstractions.Repository.Write;

namespace NetChallenge.Application.Features.Commands.Carrier.RemoveCarrier
{
    public class CarrierRemoveCommandHandler : IRequestHandler<CarrierRemoveCommadRequest, CarrierRemoveCommandResponse>
    {
        #region Fields
        private readonly ICarrierWriteRepository _carrierWriteRepository;
        #endregion

        #region Ctor
        public CarrierRemoveCommandHandler(ICarrierWriteRepository carrierWriteRepository)
        {
            _carrierWriteRepository = carrierWriteRepository;
        }
        #endregion

        #region Method
        public async Task<CarrierRemoveCommandResponse> Handle(CarrierRemoveCommadRequest request, CancellationToken cancellationToken)
        {
            await _carrierWriteRepository.RemoveAsync(request.Id);
            await _carrierWriteRepository.SaveAsync();
            return new()
            {
                Message =  "The carrier with "+ request.Id + " has been deleted."
            };
        }
        #endregion
    }
}
