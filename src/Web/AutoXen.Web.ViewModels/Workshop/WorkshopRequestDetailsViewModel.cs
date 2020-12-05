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

        public CarViewModel Car { get; set; }

        [Display(Name = "Every workshop")]
        public bool AdminChooseWorkshop { get; set; }

        [Display(Name = "The car is picked up")]
        public bool PickedUp { get; set; }

        [Display(Name = "The washing is done")]
        public bool CarWashingDone { get; set; }

        public DateTime? FinishedOn { get; set; }

        [Display(Name = "Car returned")]
        public bool ReturnedCar { get; set; }

        [Display(Name = "Other services")]
        public string OtherServices { get; set; }

        public IEnumerable<WServiceViewModel> WServices { get; set; }

        public IEnumerable<WorkshopServiceViewModel> WorkshopServices { get; set; }

        public WorkshopViewModel Workshop { get; set; }
    }
}
