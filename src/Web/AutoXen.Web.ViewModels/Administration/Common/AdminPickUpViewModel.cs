namespace AutoXen.Web.ViewModels.Administration.Common
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AdminPickUpViewModel
    {
        [Required]
        [Display(Name = "Pick up location")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Pick up location must be with a minimum length of 3 and a maximum length of 150.")]
        public string PickUpLocation { get; set; }

        [Display(Name = "Pick up time")]
        public DateTime? PickUpTime { get; set; }

        [Display(Name = "Pick up fast as possible")]
        public bool PickUpFastAsPossible { get; set; }
    }
}
