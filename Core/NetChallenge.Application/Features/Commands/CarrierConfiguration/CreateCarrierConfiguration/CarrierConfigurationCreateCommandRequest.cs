using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Application.Features.Commands.CarrierConfiguration.CreateCarrierConfiguration
{
    public class CarrierConfigurationCreateCommandRequest : IRequest<CarrierConfigurationCreateCommandResponse>
    {
        public int CarrierId { get; set; }
        public int CarrierMinDesi { get; set; }
        public int CarrierMaxDesi { get; set; }
        public decimal CarrierCost { get; set; }
    }
}
