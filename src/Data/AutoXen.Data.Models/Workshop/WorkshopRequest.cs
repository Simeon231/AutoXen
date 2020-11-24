namespace AutoXen.Data.Models.Workshop
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Data.Common.Models;
    using AutoXen.Data.Models.Car;

    public class WorkshopRequest : BaseDeletableModel<string>, IRequest
    {
        public WorkshopRequest()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public bool CarDone { get; set; }

        public int WorkshopServiceId { get; set; }

        public WorkshopService WorkshopService { get; set; }

        public string AcceptedById { get; set; }

        public ApplicationUser AcceptedBy { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public string CarId { get; set; }

        public Car Car { get; set; }

        public DateTime? FinishedOn { get; set; }

        // public ICollection<Message> Messages { get; set; }
    }
}
