namespace NetChallenge.Application.Features.Queries.Carrier.GetByIdCarrier
{
    public class GetByIdCarrierQueryResponse
    {
        public int Id { get; set; }
        public string CarrierName { get; set; }
        public int CarrierPlusDesiCost { get; set; }
        public bool CarrierIsActive { get; set; }
        public int CarrierConfigurationId { get; set; }


    }
}
