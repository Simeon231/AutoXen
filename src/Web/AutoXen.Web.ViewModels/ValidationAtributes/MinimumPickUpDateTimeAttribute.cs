namespace AutoXen.Web.ViewModels.ValidationAtributes
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class MinimumPickUpDateTimeAttribute : ValidationAttribute
    {
        public MinimumPickUpDateTimeAttribute()
        {
            this.ErrorMessage = $"The date can not be in the past and it must be atleast 30 minutes from now.";
        }

        public override bool IsValid(object value)
        {
            if (value is DateTime datetime)
            {
                if (datetime.ToUniversalTime() >= DateTime.UtcNow.AddMinutes(30))
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
