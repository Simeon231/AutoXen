namespace AutoXen.Data.Models.Insurance
{
    public class InsuranceRequestInsurance
    {
        public int Id { get; set; }

        public InsuranceRequest InsuranceRequest { get; set; }

        public string InsuranceRequestId { get; set; }

        public Insurance Insurance { get; set; }

        public int InsuranceId { get; set; }
    }
}
