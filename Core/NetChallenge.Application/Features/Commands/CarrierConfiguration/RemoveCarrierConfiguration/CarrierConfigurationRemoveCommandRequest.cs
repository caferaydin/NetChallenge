using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Application.Features.Commands.CarrierConfiguration.RemoveCarrierConfiguration
{
    public class CarrierConfigurationRemoveCommandRequest : IRequest<CarrierConfigurationRemoveCommandResponse>
    {
        public int Id { get; set; }
    }
}
