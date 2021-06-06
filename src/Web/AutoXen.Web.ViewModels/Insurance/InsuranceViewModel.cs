namespace AutoXen.Web.ViewModels.Insurance
{
    using System.ComponentModel.DataAnnotations;

    public class InsuranceViewModel
    {
        public int InsuranceId { get; set; }

        [Display(Name = "InsuranceName")]
        public string InsuranceName { get; set; }

        [Display(Name = "Price")]
        public double Price { get; set; }
    }
}
