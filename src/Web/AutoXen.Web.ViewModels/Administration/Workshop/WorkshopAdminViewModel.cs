namespace AutoXen.Web.ViewModels.Administration.Workshop
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Web.ViewModels.Common;

    public class WorkshopAdminViewModel : PickUpViewModel, IValidatableObject
    {
        [Required]
        public string Id { get; set; }

        [Display(Name = "The car is picked up")]
        public bool PickedUp { get; set; }

        [Display(Name = "The washing is done")]
        public bool WorkshopServicesDone { get; set; }

        public DateTime? FinishedOn { get; set; }

        [Display(Name = "Car returned")]
        public bool ReturnedCar { get; set; }

        [Display(Name = "Other services")]
        public string OtherServices { get; set; }

        [Required(ErrorMessage = "You must pick workshop")]
        public int WorkshopId { get; set; }

        public IEnumerable<int> ServiceIds { get; set; }

        //// TODO add note to every request (only for admin)

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.ServiceIds == null && this.OtherServices == null)
            {
                yield return new ValidationResult("You must enter atleast one problem.");
            }
        }
    }
}
