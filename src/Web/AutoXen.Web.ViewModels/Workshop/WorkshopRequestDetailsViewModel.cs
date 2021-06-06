namespace AutoXen.Web.ViewModels.Workshop
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Web.ViewModels.Cars;
    using AutoXen.Web.ViewModels.Common;
    using AutoXen.Web.ViewModels.Common.RequestInformation;

    public class WorkshopRequestDetailsViewModel : PickUpViewModel
    {
        public string Id { get; set; }

        public CarViewModel Car { get; set; }

        [Display(Name = "Every workshop")]
        public bool AdminChooseWorkshop { get; set; }

        public PickUpRequestInformationViewModel RequestInformation { get; set; }

        [Display(Name = "Other services")]
        public string OtherServices { get; set; }

        public IEnumerable<WServiceViewModel> WServices { get; set; }

        public IEnumerable<int> WorkshopServices { get; set; }

        public WorkshopViewModel Workshop { get; set; }

        public List<MessageViewModel> Messages { get; set; }
    }
}
