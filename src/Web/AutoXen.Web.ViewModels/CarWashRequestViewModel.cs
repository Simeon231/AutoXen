namespace AutoXen.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Web.ViewModels.Common;

    public class CarWashRequestViewModel
    {
        [Required]
        public string CarId { get; set; }

        public int? CarWashId { get; set; }

        public PickUpViewModel PickUp { get; set; }

        [Display(Name = "Auto Choose car wash")]
        public bool AdminChooseCarWash { get; set; }

        ////[BindNever]
        ////public IEnumerable<CarViewModel> Cars { get; set; }

        // TODO:
        // public IEnumerable<string> Messages { get; set; }
    }
}
