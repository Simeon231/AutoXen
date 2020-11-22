namespace AutoXen.Data.Models.Car
{
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Data.Common.Models;

    public class Extra : BaseModel<int>
    {
        [Required]
        public string Name { get; set; }
    }
}
