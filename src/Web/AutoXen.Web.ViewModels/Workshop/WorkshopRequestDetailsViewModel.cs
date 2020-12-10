﻿namespace AutoXen.Web.ViewModels.Workshop
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Web.ViewModels.Administration.Common;
    using AutoXen.Web.ViewModels.Cars;
    using AutoXen.Web.ViewModels.Common;

    public class WorkshopRequestDetailsViewModel : PickUpViewModel
    {
        public string Id { get; set; }

        public CarViewModel Car { get; set; }

        [Display(Name = "Every workshop")]
        public bool AdminChooseWorkshop { get; set; }

        public AdminRequestInformationViewModel RequestInformation { get; set; }

        [Display(Name = "The car was picked up")]
        public bool PickedUp { get; set; }

        [Display(Name = "The car services are done")]
        public bool ServiceFinished { get; set; }

        public DateTime? FinishedOn { get; set; }

        [Display(Name = "The Car was returned")]
        public bool ReturnedCar { get; set; }

        [Display(Name = "Other services")]
        public string OtherServices { get; set; }

        public IEnumerable<WServiceViewModel> WServices { get; set; }

        public IEnumerable<int> WorkshopServices { get; set; }

        public WorkshopViewModel Workshop { get; set; }

        public List<MessageViewModel> Messages { get; set; }
    }
}
