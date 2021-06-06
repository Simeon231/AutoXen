namespace AutoXen.Web.ViewModels.Administration.Insurance
{
    using System;
    using System.Collections.Generic;

    using AutoXen.Web.ViewModels.Common.RequestInformation;

    public class AdminInsuranceRequestViewModel
    {
        public string Id { get; set; }

        public int InsurerId { get; set; }

        public IEnumerable<int> InsurerInsurancesIds { get; set; }

        public DateTime InsuranceStart { get; set; }

        public DateTime InsuranceEnd { get; set; }

        public byte NumberOfPayments { get; set; }

        public InsuranceRequestInformationViewModel InsuranceRequestInformation { get; set; }
    }
}
