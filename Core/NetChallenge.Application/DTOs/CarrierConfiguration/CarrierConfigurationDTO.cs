using NetChallenge.Application.DTOs.Carrier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Application.DTOs.CarrierConfiguration
{
    public class CarrierConfigurationDTO
    {
        public CarrierDTO CarrierDTO { get; set; }
        public int CarrierMaxDesi { get; set; }
        public int CarrierMinDesi { get; set; }
        public decimal CarrierCost { get; set; }
    }
}
