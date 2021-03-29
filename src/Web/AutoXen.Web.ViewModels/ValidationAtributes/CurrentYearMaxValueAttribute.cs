namespace AutoXen.Web.ViewModels.ValidationAtributes
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Services;

    public class CurrentYearMaxValueAttribute : ValidationAttribute
    {
        public CurrentYearMaxValueAttribute(int minYear)
        {
            this.MinYear = minYear;
        }

        public int MinYear { get; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null && value is not short)
            {
                return new ValidationResult(this.GetErrorMessage(validationContext));
            }

            short date = (short)value;
            if (date > DateTime.UtcNow.Year
                || date < this.MinYear)
            {
                return new ValidationResult(this.GetErrorMessage(validationContext));
            }

            return ValidationResult.Success;
        }

        private string GetErrorMessage(ValidationContext validationContext)
        {
            this.ErrorMessage = "MinYearError";

            ErrorMessageTranslationService errorTranslation = validationContext.GetService(typeof(ErrorMessageTranslationService)) as ErrorMessageTranslationService;
            return string.Format(errorTranslation.GetLocalizedError(this.ErrorMessage), this.MinYear, DateTime.UtcNow.Year);
        }
    }
}
