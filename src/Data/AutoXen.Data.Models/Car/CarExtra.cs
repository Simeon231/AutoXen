namespace AutoXen.Data.Models.Car
{
    using System.ComponentModel.DataAnnotations;

    public class CarExtra
    {
        public int Id { get; set; }

        [Required]
        public string CarId { get; set; }

        public Car Car { get; set; }

        [Required]
        public int ExtraId { get; set; }

        public Extra Extra { get; set; }
    }
}
