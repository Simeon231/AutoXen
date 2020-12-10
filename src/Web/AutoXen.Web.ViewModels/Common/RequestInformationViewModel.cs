namespace AutoXen.Web.ViewModels.Common
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class RequestInformationViewModel
    {
        [Display(Name = "The car was picked up")]
        public bool PickedUp { get; set; }

        [Display(Name = "The car services are done")]
        public bool ServiceFinished { get; set; }

        public DateTime? FinishedOn { get; set; }

        [Display(Name = "The Car was returned")]
        public bool ReturnedCar { get; set; }
    }
}
