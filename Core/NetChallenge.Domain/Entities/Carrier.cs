using NetChallenge.Domain.Entities.Common;

namespace NetChallenge.Domain.Entities
{
    public class Carrier :BaseEntity
    {
        public string CarrierName { get; set; }
        public bool CarrierIsActive { get; set; }
        public int CarrierPlusDesiCost { get; set; }
        public int CarrierConfigurationId { get; set; }
        public ICollection<CarrierConfiguration> CarrierConfigurations { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}
