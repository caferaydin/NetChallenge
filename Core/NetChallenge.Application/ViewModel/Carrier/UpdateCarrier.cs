namespace NetChallenge.Application.ViewModel.Carrier
{
    public class UpdateCarrier
    {
        public int Id { get; set; }
        public string CarrierName { get; set; }
        public bool CarrierIsActive { get; set; }
        public int CarrierPlusDesiCost { get; set; }
        public int CarrierConfigurationId { get; set; }
    }
}
