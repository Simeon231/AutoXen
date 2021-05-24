namespace AutoXen.Data.Models.RoadsideAssistance
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Data.Common.Models;
    using AutoXen.Data.Models.Car;

    public class RoadsideAssistanceRequest : BaseDeletableModel<string>, IRequest
    {
        public RoadsideAssistanceRequest()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string Address { get; set; }

        public int RoadsideAssistanceId { get; set; }

        public RoadsideAssistance RoadsideAssistance { get; set; }

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
