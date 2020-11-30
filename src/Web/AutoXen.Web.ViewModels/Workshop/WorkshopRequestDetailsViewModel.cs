namespace AutoXen.Web.ViewModels.Workshop
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class WorkshopRequestDetailsViewModel
    {
        public CarViewModel Car { get; set; }

        [Display(Name = "Every workshop")]
        public bool AdminChooseWorkshop { get; set; }

        [Display(Name = "Pick up location")]
        public string PickUpLocation { get; set; }

        [Display(Name = "Pick up time")]
        public DateTime? PickUpTime { get; set; }

        [Display(Name = "Pick up fast as possible")]
        public bool PickUpFastAsPossible { get; set; }

        [Display(Name = "The car is picked up")]
        public bool PickedUp { get; set; }

        [Display(Name = "The washing is done")]
        public bool CarWashingDone { get; set; }

        public DateTime? FinishedOn { get; set; }

        [Display(Name = "Car returned")]
        public bool ReturnedCar { get; set; }

        public string OtherServices { get; set; }

        public IEnumerable<WServiceViewModel> WServices { get; set; }

        public IEnumerable<WorkshopServiceViewModel> WorkshopServices { get; set; }

        public WorkshopViewModel Workshop { get; set; }
    }
}
