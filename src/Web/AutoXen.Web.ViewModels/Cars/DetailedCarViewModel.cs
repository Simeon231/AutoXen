namespace AutoXen.Web.ViewModels.Cars
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Data.Models.Enums;
    using AutoXen.Web.ViewModels.ValidationAtributes;

    // TODO delete Mapping
    public class DetailedCarViewModel : CarViewModel
    {
        public new string Id { get; set; }

        [Display(Name = "Number of seats")]
        [Range(1, 100, ErrorMessage = "The number of seats must be atleast 1.")]
        public byte? NumberOfSeats { get; set; }

        [Display(Name = "Year made")]
        [CurrentYearMaxValue(1900)]
        public short? YearMade { get; set; }

        public int? Weight { get; set; }

        public string Color { get; set; }

        public FuelType FuelType { get; set; }

        public TransmissionType TransmissionType { get; set; }

        [StringLength(17, MinimumLength = 17, ErrorMessage = "VIN length must be 17.")]
        [Display(Name = "VIN")]
        [RegularExpression(@"^[A-Za-z0-9]{17}$", ErrorMessage = "VIN must be 17 length and have only letters and numbers")]
        public string VehicleIdentificationNumber { get; set; }

        public IEnumerable<int> CarExtras { get; set; }
    }
}
