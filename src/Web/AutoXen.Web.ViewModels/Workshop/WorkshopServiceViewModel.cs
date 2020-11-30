namespace AutoXen.Web.ViewModels.Workshop
{
    using System.ComponentModel.DataAnnotations;

    public class WorkshopServiceViewModel
    {
        [Required]
        public string ServiceName { get; set; }

        public string ServiceId { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
