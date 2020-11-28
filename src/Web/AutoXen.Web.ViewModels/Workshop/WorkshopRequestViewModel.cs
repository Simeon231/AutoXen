namespace AutoXen.Web.ViewModels.Workshop
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Web.ViewModels.Common;

    public class WorkshopRequestViewModel : IValidatableObject
    {
        public int WorkshopId { get; set; }

        public IEnumerable<int> Ids { get; set; }

        [Required]
        public string CarId { get; set; }

        public PickUpViewModel PickUp { get; set; }

        [Display(Name = "Every workshop")]
        public bool AdminChooseWorkshop { get; set; }

        [MaxLength(300)]
        [Display(Name = "Your problems are not listed? Write them here.")]
        [MinLength(5)]
        public string OtherServices { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Ids == null && this.OtherServices == null)
            {
                yield return new ValidationResult("You must enter atleast one problem");
            }
        }
    }
}
