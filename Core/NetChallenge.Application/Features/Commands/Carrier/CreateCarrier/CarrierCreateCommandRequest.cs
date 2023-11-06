using MediatR;

namespace NetChallenge.Application.Features.Commands.Carrier.CreateCarrier
{
    public class CarrierCreateCommandRequest : IRequest<CarrierCreateCommandResponse>
    {
        public string CarrierName { get; set; }
        public bool CarrierIsActive { get; set; }
        public int CarrierPlusDesiCost { get; set; }
        public int CarrierConfigurationId { get; set; }
    }
}
