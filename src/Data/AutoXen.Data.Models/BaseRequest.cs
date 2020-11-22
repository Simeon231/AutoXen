namespace AutoXen.Data.Models
{
    using System;
    using System.Collections.Generic;

    using AutoXen.Data.Common.Models;
    using AutoXen.Data.Enums;

    public class BaseRequest : BaseDeletableModel<string>
    {
        public BaseRequest()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Messages = new HashSet<Message>();
        }

        public RequestName RequestName { get; set; }

        public string AcceptedById { get; set; }

        public ApplicationUser AcceptedBy { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string CarId { get; set; }

        public Car.Car Car { get; set; }

        public DateTime FinishedOn { get; set; }

        public ICollection<Message> Messages { get; set; }
    }
}
