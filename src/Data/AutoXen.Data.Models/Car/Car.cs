namespace AutoXen.Data.Models.Car
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Data.Common.Models;
    using AutoXen.Data.Models.Enums;

    public class Car : BaseDeletableModel<string>
    {
        public Car()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CarExtras = new HashSet<CarExtra>();
            this.OtherCarUsers = new HashSet<OtherCarUser>();
        }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }

        public FuelType? FuelType { get; set; }

        public byte? NumberOfSeats { get; set; }

        public short? YearMade { get; set; }

        public int? Weight { get; set; }

        public string Color { get; set; }

        public TransmissionType? TransmissionType { get; set; }

        [MaxLength(17)]
        public string VehicleIdentificationNumber { get; set; }

        [Required]
        public string RegistrationPlate { get; set; }

        public ICollection<CarExtra> CarExtras { get; set; }

        public ICollection<OtherCarUser> OtherCarUsers { get; set; }
    }
}
