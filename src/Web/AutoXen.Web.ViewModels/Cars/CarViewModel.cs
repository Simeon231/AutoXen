namespace AutoXen.Web.ViewModels.Cars
{
    using System.ComponentModel.DataAnnotations;

    public class CarViewModel
    {
        [Required]
        public string Id { get; set; }

        [Required(ErrorMessage = "BrandRequired")]
        [Display(Name = "Brand")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "ModelRequired")]
        [Display(Name = "Model")]
        public string Model { get; set; }

        [Required(ErrorMessage = "RegistrationPlateRequired")]
        [Display(Name = "RegistrationPlate")]
        public string RegistrationPlate { get; set; }
    }
}
