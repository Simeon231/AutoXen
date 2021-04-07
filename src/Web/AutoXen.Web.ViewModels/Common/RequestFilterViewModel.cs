namespace AutoXen.Web.ViewModels.Common
{
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Common;

    public class RequestFilterViewModel : PagingViewModel
    {
        [Display(Name = GlobalConstants.Workshop)]
        public bool Workshops { get; set; }

        [Display(Name = GlobalConstants.CarWash)]
        public bool CarWashes { get; set; }

        [Display(Name = GlobalConstants.Insurance)]
        public bool Insurances { get; set; }

        [Display(Name = GlobalConstants.RoadsideAssistance)]
        public bool RoadsideAssistance { get; set; }

        [Display(Name = GlobalConstants.AnnualTechnicalInspection)]
        public bool AnnualTechnicalInspections { get; set; }

        public bool Done { get; set; }
    }
}
