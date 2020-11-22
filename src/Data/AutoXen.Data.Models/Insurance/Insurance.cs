namespace AutoXen.Data.Models.Insurance
{
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Data.Common.Models;

    public class Insurance : BaseDeletableModel<int>
    {
        [Required]
        public string Name { get; set; }
    }
}
