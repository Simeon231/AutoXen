namespace AutoXen.Data.Models.Workshop
{
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Data.Common.Models;

    public class WorkshopRequestServices : BaseModel<int>
    {
        [Required]
        public string WorkshopRequestId { get; set; }

        public WorkshopRequest WorkshopRequest { get; set; }

        public int WorkshopServiceId { get; set; }

        public WorkshopService WorkshopService { get; set; }
    }
}
