namespace AutoXen.Data.Models.CarWash
{
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Data.Common.Models;

    public class CarWash : BaseDeletableModel<int>
    {
        [Required]
        public string Name { get; set; }

        public double Price { get; set; }
    }
}
