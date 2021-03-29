namespace AutoXen.Web.ViewModels.Common
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Web.ViewModels.ValidationAtributes;

    public class PickUpViewModel
    {
        [Required(ErrorMessage = "PickUpLocationRequired")]
        [Display(Name = "PickUpLocation")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "PickUpLocationLength")]
        public string PickUpLocation { get; set; }

        [Display(Name = "PickUpTime")]
        [MinimumPickUpDateTimeAttribute]
        public DateTime? PickUpTime { get; set; }

        [Display(Name = "PickUpFastAsPossible")]
        public bool PickUpFastAsPossible { get; set; }
    }
}
