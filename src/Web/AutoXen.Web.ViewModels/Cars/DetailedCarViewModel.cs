namespace AutoXen.Web.ViewModels.Cars
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Data.Models.Enums;
    using AutoXen.Web.ViewModels.ValidationAtributes;

    public class DetailedCarViewModel : CarViewModel
    {
        public new string Id { get; set; }

        [Display(Name = "Seats")]
        [Range(1, 100, ErrorMessage = "SeatsMinError")]
        public byte? NumberOfSeats { get; set; }

        [Display(Name = "YearMade")]
        [CurrentYearMaxValue(1900)]
        public short? YearMade { get; set; }

        [Display(Name = "Weight")]
        public int? Weight { get; set; }

        [Display(Name = "Color")]
        public string Color { get; set; }

        [Display(Name = "FuelType")]
        public FuelType FuelType { get; set; }

        [Display(Name = "TransmissionType")]
        public TransmissionType TransmissionType { get; set; }

        [StringLength(17, MinimumLength = 17, ErrorMessage = "VINLengthError")]
        [Display(Name = "VIN")]
        [RegularExpression(@"^[A-Za-z0-9]{17}$", ErrorMessage = "VinRegularExpression")]
        public string VehicleIdentificationNumber { get; set; }

        public IEnumerable<int> CarExtraIds { get; set; }
    }
}
