namespace AutoXen.Data.Models.Workshop
{
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Data.Common.Models;

    public class WService : BaseModel<int>
    {
        [Required]
        public string Name { get; set; }
    }
}
