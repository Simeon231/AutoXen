namespace AutoXen.Web.ViewModels.ValidationAtributes
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CurrentYearMaxValueAttribute : ValidationAttribute
    {
        public CurrentYearMaxValueAttribute(int minYear)
        {
            this.MinYear = minYear;
            this.ErrorMessage = $"Value should be between {minYear} and {DateTime.UtcNow.Year}.";
        }

        public int MinYear { get; }

        public override bool IsValid(object value)
        {
            if (value is short intValue)
            {
                if (intValue <= DateTime.UtcNow.Year
                    && intValue >= this.MinYear)
                {
                    return true;
                }
            }

            if (value is null)
            {
                return true;
            }

            return false;
        }
    }
}
