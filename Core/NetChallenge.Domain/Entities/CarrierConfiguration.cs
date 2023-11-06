using NetChallenge.Domain.Entities.Common;

namespace NetChallenge.Domain.Entities
{
    public class CarrierConfiguration :BaseEntity
    {
        public int CarrierId { get; set; }
        public Carrier Carrier { get; set; }
        public int CarrierMaxDesi { get; set; }
        public int CarrierMinDesi { get; set; }
        public decimal CarrierCost { get; set; }
    }
}
