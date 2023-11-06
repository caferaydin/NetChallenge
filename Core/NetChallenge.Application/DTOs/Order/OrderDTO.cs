namespace NetChallenge.Application.DTOs.Order
{
    public class OrderDTO
    {
        public string CarrierName { get; set; }
        public int OrderDesi { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderCarrierCost { get; set; }
    }
}
