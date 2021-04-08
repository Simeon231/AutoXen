namespace AutoXen.Data.Models.Workshop
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Data.Common.Models;
    using AutoXen.Data.Models.Car;
    using AutoXen.Data.Models.Enums;

    public class WorkshopRequest : BaseDeletableModel<string>, IRequest
    {
        private DateTime? pickUpTime;
        private DateTime? finishedOn;

        public WorkshopRequest()
        {
            this.Id = Guid.NewGuid().ToString();
            this.WorkshopRequestWorkshopServices = new HashSet<WorkshopRequestWorkshopService>();
            this.WorkshopRequestWServices = new HashSet<WorkshopRequestWService>();
        }

        public bool ServiceFinished { get; set; }

        public DateTime? FinishedOn
        {
            get => this.finishedOn;
            set
            {
                if (value != null)
                {
                    this.finishedOn = ((DateTime)value).ToUniversalTime();
                }
            }
        }

        public bool ReturnedCar { get; set; }

        public bool PickedUp { get; set; }

        public bool AdminChooseWorkshop { get; set; }

        [Required]
        [MaxLength(150)]
        public string PickUpLocation { get; set; }

        public bool PickUpFastAsPossible { get; set; }

        public DateTime? PickUpTime
        {
            get => this.pickUpTime;
            set
            {
                if (value != null)
                {
                    this.pickUpTime = ((DateTime)value).ToUniversalTime();
                }
            }
        }

        [MaxLength(300)]
        public string OtherServices { get; set; }

        public ICollection<WorkshopRequestWorkshopService> WorkshopRequestWorkshopServices { get; set; }

        public ICollection<WorkshopRequestWService> WorkshopRequestWServices { get; set; }

        public string AcceptedById { get; set; }

        public ApplicationUser AcceptedBy { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public string CarId { get; set; }

        public Car Car { get; set; }

        //// public ICollection<Message> Messages { get; set; }

        // Used by WorkshopProfile
        public override string ToString()
        {
            return RequestName.Workshop.ToString();
        }
    }
}
