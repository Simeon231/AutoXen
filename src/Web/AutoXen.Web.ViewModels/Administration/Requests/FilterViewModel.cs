namespace AutoXen.Web.ViewModels.Administration.Requests
{
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Common;
    using AutoXen.Web.ViewModels.Common;

    public class FilterViewModel : PagingViewModel
    {
        public bool Accepted { get; set; }

        public bool AcceptedByMe { get; set; }

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
    }
}
