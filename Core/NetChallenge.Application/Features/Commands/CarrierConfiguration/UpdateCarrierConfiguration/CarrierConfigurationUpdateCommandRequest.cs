using MediatR;

namespace NetChallenge.Application.Features.Commands.CarrierConfiguration.UpdateCarrierConfiguration
{
    public class CarrierConfigurationUpdateCommandRequest : IRequest<CarrierConfigurationUpdateCommandResponse>
    {
        public int Id { get; set; }
        public int CarrierMinDesi { get; set; }
        public int CarrierMaxdesi { get; set; }
        public decimal CarrierCost { get; set; }
    }
}
