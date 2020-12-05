namespace AutoXen.Web.ViewModels.Workshop
{
    using System.ComponentModel.DataAnnotations;

    public class WorkshopServiceViewModel
    {
        [Required]
        public string ServiceName { get; set; }

        public int ServiceId { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
