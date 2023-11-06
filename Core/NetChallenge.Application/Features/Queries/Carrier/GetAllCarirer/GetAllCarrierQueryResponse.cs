namespace NetChallenge.Application.Features.Queries.Carrier.GetAllCarirer
{
    public class GetAllCarrierQueryResponse
    {
        public int TotalCarrierCount { get; set; }
        public bool Success { get; set; }
        public object Carriers { get; set; }
    }
}
