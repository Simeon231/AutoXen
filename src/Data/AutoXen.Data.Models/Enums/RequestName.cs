namespace AutoXen.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum RequestName
    {
        Workshop = 1,
        [Display(Name="Annual technicall inspection")]
        Annual_technicall_inspection = 2,
        [Display(Name = "Car wash")]
        Car_wash = 3,
        Insurance = 4,
        [Display(Name = "Roadside assistance")]
        Roadside_assistance = 5,
    }
}
