namespace AutoXen.Data.Models.RoadsideAssistance
{
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Data.Common.Models;

    public class Province : BaseModel<int>
    {
        [Required]
        public string Name { get; set; }
    }
}
