namespace AutoXen.Web.ViewModels.Common
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Web.ViewModels.ValidationAtributes;

    public class PickUpViewModel
    {
        [Required]
        [Display(Name = "Pick up location")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Pick up location must be with a minimum length of 3 and a maximum length of 150.")]
        public string Location { get; set; }

        [Display(Name = "Pick up time")]
        [MinimumPickUpDateTimeAttribute]
        public DateTime? Time { get; set; }

        [Display(Name = "Pick up fast as possible")]
        public bool FastAsPossible { get; set; }
    }
}
