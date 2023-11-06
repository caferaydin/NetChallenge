using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Application.Features.Queries.CarrierConfiguration.GetByIdCarrierConfiguration
{
    public class GetByIdCarrierConfigurationQueryRequest : IRequest<GetByIdCarrierConfigurationQueryResponse>
    {
        public int Id { get; set; }
    }
}
