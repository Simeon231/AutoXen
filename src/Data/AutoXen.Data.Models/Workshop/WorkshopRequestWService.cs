namespace AutoXen.Data.Models.Workshop
{
    using System.ComponentModel.DataAnnotations;

    public class WorkshopRequestWService
    {
        public int Id { get; set; }

        public int WServiceId { get; set; }

        public WService WService { get; set; }

        [Required]
        public string WorkshopRequestId { get; set; }

        public WorkshopRequest WorkshopRequest { get; set; }
    }
}
