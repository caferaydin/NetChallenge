using MediatR;

namespace NetChallenge.Application.Features.Commands.Carrier.RemoveCarrier
{
    public class CarrierRemoveCommadRequest : IRequest<CarrierRemoveCommandResponse>
    {
        public int Id { get; set; }
    }
}
