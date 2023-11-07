using NetChallenge.Application.DTOs.Carrier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Application.DTOs.CarrierReport
{
    public class CarrierReportDTO
    {
        public CarrierDTO Carrier { get; set; }
        public Decimal CarrierCost { get; set; }
        public DateTime CarrierReportDate { get; set; }
    }
}
