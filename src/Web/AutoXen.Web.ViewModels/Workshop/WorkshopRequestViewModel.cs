namespace AutoXen.Web.ViewModels.Workshop
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Web.ViewModels.Common;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public class WorkshopRequestViewModel
    {
        public string WorkshopId { get; set; }

        [Required]
        public IEnumerable<int> ServiceIds { get; set; }

        [Required]
        public string CarId { get; set; }

        public PickUpViewModel PickUp { get; set; }

        [Display(Name = "Every workshop")]
        public bool AdminChooseWorkshop { get; set; }

        [BindNever]
        public IEnumerable<WorkshopViewModel> Workshops { get; set; }

        [BindNever]
        public IEnumerable<CarViewModel> Cars { get; set; }

        [BindNever]
        public IEnumerable<WorkshopServiceViewModel> WorkshopsServices { get; set; }

        [BindNever]
        public IEnumerable<ServiceModel> Services { get; set; }
    }
}
