namespace AutoXen.Web.ViewModels.Common
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Web.ViewModels.Validation_Atributes;

    public class PickUpViewModel
    {
        [Required]
        [Display(Name = "Pick up location")]
        [StringLength(150, MinimumLength = 3)]
        public string Location { get; set; }

        [Display(Name = "Pick up time")]
        [MinimumPickUpDateTimeAttribute]
        public DateTime? Time { get; set; }

        [Display(Name = "Pick up fast as possible")]
        public bool FastAsPossible { get; set; }
    }
}
