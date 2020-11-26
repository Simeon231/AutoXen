namespace AutoXen.Web.ViewModels.Workshop
{
    using System.ComponentModel.DataAnnotations;

    public class WorkshopServiceViewModel
    {
        [Required]
        public string WorkshopName { get; set; }

        public string WorkshopId { get; set; }

        [Required]
        public string WorkshopAddress { get; set; }

        [Required]
        public string ServiceName { get; set; }

        public string ServiceId { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
