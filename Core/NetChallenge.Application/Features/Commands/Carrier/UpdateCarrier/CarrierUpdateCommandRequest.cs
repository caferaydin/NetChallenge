using MediatR;

namespace NetChallenge.Application.Features.Commands.Carrier.UpdateCarrier
{
    public class CarrierUpdateCommandRequest : IRequest<CarrierUpdateCommandResponse>
    {
        public int Id { get; set; }
        public string CarrierName { get; set; }
        public bool CarrierIsActive { get; set; }
        public int CarrierPlusDesiCost { get; set; }
        public int CarrierConfigurationId { get; set; }
    }
}
