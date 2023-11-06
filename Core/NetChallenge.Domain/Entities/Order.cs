using NetChallenge.Domain.Entities.Common;

namespace NetChallenge.Domain.Entities
{
    public class Order : BaseEntity
    {
        public int CarrierId { get; set; }
        public Carrier Carrier { get; set; } 
        public int OrderDesi { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderCarrierCost { get; set; }

    }
}
