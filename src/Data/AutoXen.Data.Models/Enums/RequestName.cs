namespace AutoXen.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum RequestName
    {
        [Display(Name = "Workshop")]
        Workshop = 1,
        [Display(Name= "AnnualTechnicallInspection")]
        AnnualTechnicallInspection = 2,
        [Display(Name = "CarWash")]
        CarWash = 3,
        [Display(Name = "Insurance")]
        Insurance = 4,
        [Display(Name = "RoadsideAssistance")]
        RoadsideAssistance = 5,
    }
}
