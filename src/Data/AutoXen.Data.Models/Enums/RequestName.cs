namespace AutoXen.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum RequestName
    {
        [Display(Name = "Workshop")]
        Workshop = 1,
        [Display(Name= "Annual_technicall_inspection")]
        Annual_technicall_inspection = 2,
        [Display(Name = "CarWash")]
        Car_wash = 3,
        [Display(Name = "Insurance")]
        Insurance = 4,
        [Display(Name = "Roadside_assistance")]
        Roadside_assistance = 5,
    }
}
