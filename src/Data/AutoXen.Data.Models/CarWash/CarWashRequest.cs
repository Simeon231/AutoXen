namespace AutoXen.Data.Models.CarWash
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Data.Common.Models;
    using AutoXen.Data.Models.Enums;

    public class CarWashRequest : BaseDeletableModel<string>, IRequest
    {
        private DateTime? pickUpTime;
        private DateTime? finishedOn;

        public CarWashRequest()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string PickUpLocation { get; set; }

        public bool PickUpFastAsPossible { get; set; }

        public bool AdminChooseCarWash { get; set; }

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

        public bool PickedUp { get; set; }

        public bool ServiceFinished { get; set; }

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

        //// public ICollection<Message> Messages { get; set; }

        public override string ToString()
        {
            return RequestName.CarWash.ToString();
        }
    }
}
