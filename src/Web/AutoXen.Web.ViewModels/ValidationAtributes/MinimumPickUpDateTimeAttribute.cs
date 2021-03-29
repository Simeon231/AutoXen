namespace AutoXen.Web.ViewModels.ValidationAtributes
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Services;

    public class MinimumPickUpDateTimeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is null)
            {
                return ValidationResult.Success;
            }

            if (value is DateTime datetime)
            {
                if (datetime.ToUniversalTime() >= DateTime.UtcNow.AddMinutes(30))
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult(this.GetErrorMessage(validationContext));
        }

        private string GetErrorMessage(ValidationContext validationContext)
        {
            this.ErrorMessage = "DateCantBeInThePast";

            ErrorMessageTranslationService errorTranslation = validationContext.GetService(typeof(ErrorMessageTranslationService)) as ErrorMessageTranslationService;
            return errorTranslation.GetLocalizedError(this.ErrorMessage);
        }
    }
}
