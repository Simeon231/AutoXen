namespace AutoXen.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Data.Models.CarWash;
    using AutoXen.Services.Mapping;
    using AutoXen.Web.ViewModels.Common;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public class CarWashRequestViewModel : IMapFrom<CarWashRequest>
    {
        [Required]
        public string CarId { get; set; }

        public string CarWashId { get; set; }

        public PickUpViewModel PickUp { get; set; }

        [Display(Name = "Auto Choose car wash")]
        public bool AdminChooseCarWash { get; set; }

        [BindNever]
        public IEnumerable<CarViewModel> Cars { get; set; }

        // TODO:
        // public IEnumerable<string> Messages { get; set; }
    }
}
