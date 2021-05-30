namespace AutoXen.Web.ViewModels.Common.RequestInformation
{
    using System.ComponentModel.DataAnnotations;

    public class PickUpRequestInformationViewModel : BasicRequestInformation
    {
        [Display(Name = "The car was picked up")]
        public bool PickedUp { get; set; }

        [Display(Name = "The car services are done")]
        public bool ServiceFinished { get; set; }

        [Display(Name = "The Car was returned")]
        public bool ReturnedCar { get; set; }

        public string UserId { get; set; }
    }
}
