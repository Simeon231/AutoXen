namespace AutoXen.Web.ViewModels.Workshop
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Services;
    using AutoXen.Web.ViewModels.Common;

    public class WorkshopRequestViewModel : PickUpViewModel, IValidatableObject
    {
        // TODO add required translations
        public int WorkshopId { get; set; }

        public IEnumerable<int> Ids { get; set; }

        [Required]
        public string CarId { get; set; }

        [Display(Name = "EveryWorkshop")]
        public bool AdminChooseWorkshop { get; set; }

        [Display(Name = "ProblemsNotListed")]
        [MaxLength(300, ErrorMessage = "OtherServicesMaximumLength")]
        [MinLength(5, ErrorMessage = "OtherServicesMinimumLength")]
        public string OtherServices { get; set; }

        [Display(Name = "Message")]
        public string Message { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Ids == null && this.OtherServices == null)
            {
                yield return new ValidationResult(this.GetErrorMessage(validationContext));
            }
        }

        private string GetErrorMessage(ValidationContext validationContext)
        {
            var error = "AtleastOne";

            ErrorMessageTranslationService errorTranslation = validationContext.GetService(typeof(ErrorMessageTranslationService)) as ErrorMessageTranslationService;
            return errorTranslation.GetLocalizedError(error);
        }
    }
}
