namespace AutoXen.Web.ViewModels.Administration.CarWash
{
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Web.ViewModels.Administration.Common;
    using AutoXen.Web.ViewModels.Cars;
    using AutoXen.Web.ViewModels.Common;

    public class AdminCarWashDetailsViewModel : AdminPickUpViewModel
    {
        public string Id { get; set; }

        public CarViewModel Car { get; set; }

        [Required(ErrorMessage = "The car wash is required")]
        public int? CarWashId { get; set; }

        [Display(Name = "Every car wash")]
        public bool AdminChooseCarWash { get; set; }

        public AdminRequestInformationViewModel RequestInformation { get; set; }
    }
}
