namespace AutoXen.Data.Models.Insurance
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class InsurersRequest
    {
        public InsurersRequest()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public DateTime InsurenceStart { get; set; }

        public byte NumberOfInsuranceContributions { get; set; }

        [Required]
        public string BaseRequestId { get; set; }

        public BaseRequest BaseRequest { get; set; }

        public int InsurerInsurancesId { get; set; }

        public InsurerInsurances InsurerInsurances { get; set; }
    }
}
