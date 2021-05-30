namespace AutoXen.Web.ViewModels.CarWash
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Web.ViewModels.Cars;
    using AutoXen.Web.ViewModels.Common;
    using AutoXen.Web.ViewModels.Common.RequestInformation;

    public class CarWashRequestDetailsViewModel : PickUpViewModel
    {
        public string Id { get; set; }

        public CarViewModel Car { get; set; }

        public int? CarWashId { get; set; }

        public PickUpRequestInformationViewModel RequestInformation { get; set; }

        [Display(Name = "Every car wash")]
        public bool AdminChooseCarWash { get; set; }

        public IEnumerable<MessageViewModel> Messages { get; set; }
    }
}
