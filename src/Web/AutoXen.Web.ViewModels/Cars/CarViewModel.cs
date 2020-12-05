namespace AutoXen.Web.ViewModels.Cars
{
    using System.ComponentModel.DataAnnotations;

    public class CarViewModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        [Display(Name = "Registration plate")]
        public string RegistrationPlate { get; set; }
    }
}
