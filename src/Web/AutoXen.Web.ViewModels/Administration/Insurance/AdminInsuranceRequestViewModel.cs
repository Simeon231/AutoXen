namespace AutoXen.Web.ViewModels.Administration.Insurance
{
    using AutoXen.Web.ViewModels.Cars;
    using AutoXen.Web.ViewModels.Common.RequestInformation;

    public class AdminInsuranceRequestViewModel
    {
        public string Id { get; set; }

        public CarViewModel Car { get; set; }

        public InsuranceRequestInformationViewModel InsuranceRequestInformation { get; set; }
    }
}
