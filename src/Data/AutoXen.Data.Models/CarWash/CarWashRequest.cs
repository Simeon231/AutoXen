namespace AutoXen.Data.Models.CarWash
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Data.Common.Models;

    public class CarWashRequest
    {
        public CarWashRequest()
        {
            this.Id = Guid.NewGuid().ToString();
            this.BaseRequest = new BaseRequest();
        }

        public string Id { get; set; }

        [Required]
        public string PickUpLocation { get; set; }

        public bool PickUpFastAsPossible { get; set; }

        public bool AdminChooseCarWash { get; set; }

        public DateTime? PickUpTime { get; set; }

        public bool PickedUp { get; set; }

        public bool WashingFinished { get; set; }

        public bool ReturnedCar { get; set; }

        [Required]
        public string BaseRequestId { get; set; }

        public BaseRequest BaseRequest { get; set; }

        public int CarWashId { get; set; }

        public CarWash CarWash { get; set; }
    }
}
