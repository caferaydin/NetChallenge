﻿using NetChallenge.Application.DTOs.CarrierConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Application.DTOs.Carrier
{
    public class CarrierDTO
    {
        public string CarrierName { get; set; }
        public bool CarrierIsActive { get; set; }
        public int CarrierPlusDesiCost { get; set; }
        public CarrierConfigurationDTO CarrierConfiguration { get; set; }
    }
}
