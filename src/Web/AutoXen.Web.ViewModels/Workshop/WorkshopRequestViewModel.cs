namespace AutoXen.Web.ViewModels.Workshop
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Web.ViewModels.Common;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    // TODO ServiceIds or OtherServices must be not null
    public class WorkshopRequestViewModel
    {
        public int WorkshopId { get; set; }

        public IEnumerable<int> Ids { get; set; }

        [Required]
        public string CarId { get; set; }

        public PickUpViewModel PickUp { get; set; }

        [Display(Name = "Every workshop")]
        public bool AdminChooseWorkshop { get; set; }

        [MaxLength(300)]
        [Display(Name = "Your problems are not listed? Write them here.")]
        public string OtherServices { get; set; }
    }
}
