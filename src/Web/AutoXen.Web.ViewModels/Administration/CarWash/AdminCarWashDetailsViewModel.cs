namespace AutoXen.Web.ViewModels.Administration.CarWash
{
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Web.ViewModels.Administration.Common;
    using AutoXen.Web.ViewModels.Common.RequestInformation;

    public class AdminCarWashDetailsViewModel : AdminPickUpViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "The car wash is required")]
        public int? CarWashId { get; set; }

        [Display(Name = "Every car wash")]
        public bool AdminChooseCarWash { get; set; }

        public PickUpRequestInformationViewModel RequestInformation { get; set; }
    }
}
