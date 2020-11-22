namespace AutoXen.Data.Models.AnnualTechnicalInspection
{
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Data.Common.Models;

    public class AnnualTechnicalInspection : BaseDeletableModel<int>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        public double Price { get; set; }
    }
}
