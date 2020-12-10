﻿namespace AutoXen.Web.ViewModels.CarWash
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Web.ViewModels.Administration.Common;
    using AutoXen.Web.ViewModels.Cars;
    using AutoXen.Web.ViewModels.Common;

    public class CarWashRequestDetailsViewModel : PickUpViewModel
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public CarViewModel Car { get; set; }

        public int? CarWashId { get; set; }

        public AdminRequestInformationViewModel RequestInformation { get; set; }

        [Display(Name = "Every car wash")]
        public bool AdminChooseCarWash { get; set; }

        public IEnumerable<MessageViewModel> Messages { get; set; }
    }
}
