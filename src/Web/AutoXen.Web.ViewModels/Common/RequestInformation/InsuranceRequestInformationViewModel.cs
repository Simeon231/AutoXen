namespace AutoXen.Web.ViewModels.Common.RequestInformation
{
    using System.ComponentModel.DataAnnotations;

    public class InsuranceRequestInformationViewModel : BasicRequestInformation
    {
        [Display(Name = "InsurancesSent")]
        public bool InsurancesSent { get; set; }

        [Display(Name = "InsurancesReceived")]
        public bool InsurancesReceived { get; set; }

        public string UserId { get; set; }
    }
}
