using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Application.Features.Queries.CarrierConfiguration.GetAllCarrierConfiguration
{
    public class GetAllCarrierConfigurationQueryReponse
    {
        public int TotalCarrierConfigurationCount { get; set; }
        public bool IsSuccess { get; set; }
        public object CarrierConfiguarions { get; set; }
    }
}
