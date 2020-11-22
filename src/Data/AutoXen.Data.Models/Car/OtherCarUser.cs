namespace AutoXen.Data.Models.Car
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Data.Common.Models;

    public class OtherCarUser : BaseDeletableModel<string>
    {
        public OtherCarUser()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string Address { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string MiddleName { get; set; }

        [Required]
        public string SurName { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string CarId { get; set; }

        public Car Car { get; set; }
    }
}
