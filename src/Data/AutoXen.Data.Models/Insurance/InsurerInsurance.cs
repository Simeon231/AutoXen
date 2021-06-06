namespace AutoXen.Data.Models.Insurance
{
    using System.ComponentModel.DataAnnotations;

    public class InsurerInsurance
    {
        public int Id { get; set; }

        public double Price { get; set; }

        [Required]
        public int InsurerId { get; set; }

        public Insurer Insurer { get; set; }

        [Required]
        public int InsuranceId { get; set; }

        public Insurance Insurance { get; set; }
    }
}
