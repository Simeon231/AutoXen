namespace AutoXen.Data.Models.CarWash
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Data.Common.Models;

    public class CarWashRequest : BaseDeletableModel<string>, IRequest
    {
        public CarWashRequest()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string PickUpLocation { get; set; }

        public bool PickUpFastAsPossible { get; set; }

        public bool AdminChooseCarWash { get; set; }

        public DateTime? PickUpTime { get; set; }

        public bool PickedUp { get; set; }

        public bool WashingFinished { get; set; }

        public bool ReturnedCar { get; set; }

        public int? CarWashId { get; set; }

        public CarWash CarWash { get; set; }

        public string AcceptedById { get; set; }

        public ApplicationUser AcceptedBy { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public string CarId { get; set; }

        public Car.Car Car { get; set; }

        public DateTime? FinishedOn { get; set; }

        // public ICollection<Message> Messages { get; set; }
    }
}
