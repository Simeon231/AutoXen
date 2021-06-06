namespace AutoXen.Web.ViewModels.Administration.Insurance
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Web.ViewModels.Common.RequestInformation;

    public class AdminInsuranceRequestViewModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public int InsurerId { get; set; }

        [Required]
        public IEnumerable<int> InsurancesIds { get; set; }

        [Required]
        public DateTime InsuranceStart { get; set; }

        [Required]
        public DateTime InsuranceEnd { get; set; }

        [Required]
        public byte NumberOfPayments { get; set; }

        public InsuranceRequestInformationViewModel RequestInformation { get; set; }
    }
}
