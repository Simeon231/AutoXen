namespace AutoXen.Web.ViewModels.Insurance
{
    using System.ComponentModel.DataAnnotations;

    public class InsuranceRequestViewModel
    {
        [Required]
        public string CarId { get; set; }

        public string Message { get; set; }
    }
}
