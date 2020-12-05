namespace AutoXen.Web.ViewModels.Workshop
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Web.ViewModels.Common;

    public class WorkshopRequestViewModel : PickUpViewModel, IValidatableObject
    {
        public int WorkshopId { get; set; }

        public IEnumerable<int> Ids { get; set; }

        [Required]
        public string CarId { get; set; }

        [Display(Name = "Every workshop")]
        public bool AdminChooseWorkshop { get; set; }

        [Display(Name = "Your problems are not listed? Write them here.")]
        [MaxLength(300, ErrorMessage = "Maximum length is 300.")]
        [MinLength(5, ErrorMessage = "Minimum length is 5.")]
        public string OtherServices { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Ids == null && this.OtherServices == null)
            {
                yield return new ValidationResult("You must enter atleast one problem.");
            }
        }
    }
}
