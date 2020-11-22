namespace AutoXen.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Data.Models.Car;
    using AutoXen.Services.Mapping;

    public class CarViewModel : IMapFrom<Car>
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string RegistrationPlate { get; set; }
    }
}
