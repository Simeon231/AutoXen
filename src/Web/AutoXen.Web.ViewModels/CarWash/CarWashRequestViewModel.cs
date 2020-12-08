﻿namespace AutoXen.Web.ViewModels.CarWash
{
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Web.ViewModels.Common;

    public class CarWashRequestViewModel : PickUpViewModel
    {
        [Required]
        public string CarId { get; set; }

        public int? CarWashId { get; set; }

        [Display(Name = "Auto Choose car wash")]
        public bool AdminChooseCarWash { get; set; }

        ////[BindNever]
        ////public IEnumerable<CarViewModel> Cars { get; set; }

        // TODO Add messages
        // public IEnumerable<string> Messages { get; set; }
    }
}