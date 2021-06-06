namespace AutoXen.Data.Models.Insurance
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Data.Common.Models;
    using AutoXen.Data.Models.Enums;

    public class InsuranceRequest : BaseDeletableModel<string>, IRequest
    {
        public InsuranceRequest()
        {
            this.Id = Guid.NewGuid().ToString();
            this.InsuranceRequestsInsurerInsurances = new HashSet<InsuranceRequestInsurerInsurance>();
        }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string AcceptedById { get; set; }

        public ApplicationUser AcceptedBy { get; set; }

        [Required]
        public string CarId { get; set; }

        public Car.Car Car { get; set; }

        public DateTime InsurenceStart { get; set; }

        public DateTime InsuranceEnd { get; set; }

        public byte NumberOfPayments { get; set; }

        public IEnumerable<InsuranceRequestInsurerInsurance> InsuranceRequestsInsurerInsurances { get; set; }

        public DateTime? FinishedOn { get; set; }

        public bool InsurancesSent { get; set; }

        public bool InsurancesReceived { get; set; }

        // public ICollection<Message> Messages { get; set; }

        // Used by InsuranceProfile
        public override string ToString()
        {
            return RequestName.Insurance.ToString();
        }
    }
}
