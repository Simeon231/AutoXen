namespace AutoXen.Web.ViewModels.Workshop
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Web.ViewModels.Cars;
    using AutoXen.Web.ViewModels.Common;

    public class WorkshopRequestDetailsViewModel : PickUpViewModel
    {
        public string Id { get; set; }

        // TODO Add user in view
        public string UserId { get; set; }

        public CarViewModel Car { get; set; }

        [Display(Name = "Every workshop")]
        public bool AdminChooseWorkshop { get; set; }

        [Display(Name = "The car was picked up")]
        public bool PickedUp { get; set; }

        [Display(Name = "The car services are done")]
        public bool WorkshopServicesDone { get; set; }

        public DateTime? FinishedOn { get; set; }

        [Display(Name = "The Car was returned")]
        public bool ReturnedCar { get; set; }

        [Display(Name = "Other services")]
        public string OtherServices { get; set; }

        public IEnumerable<WServiceViewModel> WServices { get; set; }

        public IEnumerable<int> WorkshopServices { get; set; }

        public WorkshopViewModel Workshop { get; set; }
    }
}
