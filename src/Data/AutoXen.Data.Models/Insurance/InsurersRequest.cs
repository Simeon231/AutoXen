namespace AutoXen.Data.Models.Insurance
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Data.Common.Models;

    // InsuranceRequest
    public class InsurersRequest : BaseDeletableModel<string>, IRequest
    {
        public InsurersRequest()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public DateTime InsurenceStart { get; set; }

        public byte NumberOfInsuranceContributions { get; set; }

        public int InsurerInsurancesId { get; set; }

        public InsurerInsurances InsurerInsurances { get; set; }

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
