namespace AutoXen.Data.Models.Insurance
{
    using AutoXen.Data.Common.Models;

    public class InsuranceRequestInsurerInsurance : BaseModel<int>
    {
        public InsuranceRequest InsuranceRequest { get; set; }

        public string InsuranceRequestId { get; set; }

        public InsurerInsurance InsurerInsurance { get; set; }

        public int InsurerInsuranceId { get; set; }
    }
}
