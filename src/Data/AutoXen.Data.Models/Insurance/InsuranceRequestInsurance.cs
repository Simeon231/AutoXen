namespace AutoXen.Data.Models.Insurance
{
    using System.ComponentModel.DataAnnotations;

    public class InsuranceRequestInsurance
    {
        public int Id { get; set; }

        public InsuranceRequest InsuranceRequest { get; set; }

        [Required]
        public string InsuranceRequestId { get; set; }

        public Insurance Insurance { get; set; }

        public int InsuranceId { get; set; }
    }
}
