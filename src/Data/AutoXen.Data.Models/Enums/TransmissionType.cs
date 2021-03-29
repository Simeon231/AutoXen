namespace AutoXen.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum TransmissionType
    {
        [Display(Name = "Unknown")]
        Unknown = 0,
        [Display(Name = "Automated")]
        Automated = 1,
        [Display(Name = "Manual")]
        Manual = 2,
        [Display(Name = "SemiAuto")]
        SemiAuto = 3,
    }
}
