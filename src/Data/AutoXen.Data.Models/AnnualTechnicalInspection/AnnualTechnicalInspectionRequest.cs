namespace AutoXen.Data.Models.AnnualTechnicalInspection
{
    using System;

    public class AnnualTechnicalInspectionRequest
    {
        public AnnualTechnicalInspectionRequest()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public bool CarDone { get; set; }

        public string BaseRequestId { get; set; }

        public BaseRequest BaseRequest { get; set; }

        public int AnnualTechnicalInspectionId { get; set; }

        public AnnualTechnicalInspection AnnualTechnicalInspection { get; set; }
    }
}
