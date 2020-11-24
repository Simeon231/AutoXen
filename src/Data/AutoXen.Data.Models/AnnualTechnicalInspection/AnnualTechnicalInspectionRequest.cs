namespace AutoXen.Data.Models.AnnualTechnicalInspection
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Data.Common.Models;

    public class AnnualTechnicalInspectionRequest : BaseDeletableModel<string>, IRequest
    {
        public AnnualTechnicalInspectionRequest()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public bool CarDone { get; set; }

        public int AnnualTechnicalInspectionId { get; set; }

        public AnnualTechnicalInspection AnnualTechnicalInspection { get; set; }

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
