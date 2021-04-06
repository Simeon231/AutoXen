namespace AutoXen.Web.ViewModels.Administration.Requests
{
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Web.ViewModels.Common;

    public class AdminFilterViewModel : RequestFilterViewModel
    {
        [Display(Name = "Accepted")]
        public bool Accepted { get; set; }

        [Display(Name = "Accepted by me")]
        public bool AcceptedByMe { get; set; }
    }
}
