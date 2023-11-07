using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Application.DTOs.CarrierConfiguration
{
    public class GetCarrierConfigurationDTO
    {
        public int CarrierMinDesi { get; set; }
        public int CarrierMaxDesi { get; set; }
        public decimal CarrierCost { get; set; }
    }
}
