namespace AutoXen.Data.Models
{
    using System;

    public interface IRequest
    {
        public string Id { get; set; }

        public string AcceptedById { get; set; }

        public ApplicationUser AcceptedBy { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string CarId { get; set; }

        public Car.Car Car { get; set; }

        public DateTime? FinishedOn { get; set; }
    }
}
