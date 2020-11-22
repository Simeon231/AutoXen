namespace AutoXen.Data.Models.Workshop
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class WorkshopRequest
    {
        public WorkshopRequest()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        public string BaseRequestId { get; set; }

        public BaseRequest BaseRequest { get; set; }

        public bool CarDone { get; set; }

        public int WorkshopServiceId { get; set; }

        public WorkshopService WorkshopService { get; set; }
    }
}
