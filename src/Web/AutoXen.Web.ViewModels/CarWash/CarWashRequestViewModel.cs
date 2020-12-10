namespace AutoXen.Web.ViewModels.CarWash
{
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Web.ViewModels.Common;

    public class CarWashRequestViewModel : PickUpViewModel
    {
        [Required]
        public string CarId { get; set; }

        public int? CarWashId { get; set; }

        [Display(Name = "Every car wash")]
        public bool AdminChooseCarWash { get; set; }

        public string Message { get; set; }
    }
}
