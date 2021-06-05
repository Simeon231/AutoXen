namespace AutoXen.Web.ViewModels.Insurance
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Web.ViewModels.Cars;
    using AutoXen.Web.ViewModels.Common;
    using AutoXen.Web.ViewModels.Common.RequestInformation;

    public class InsuranceRequestDetailsViewModel
    {
        public string Id { get; set; }

        public CarViewModel Car { get; set; }

        [Display(Name = "InsurerName")]
        public InsurerViewModel Insurer { get; set; }

        [Display(Name = "InsurerInsurances")]
        public IEnumerable<InsurerInsuranceViewModel> InsurerInsurances { get; set; }

        [Display(Name = "InsuranceStart")]
        public DateTime InsuranceStart { get; set; }

        [Display(Name = "InsuranceEnd")]
        public DateTime InsuranceEnd { get; set; }

        [Display(Name = "NumberOfPayments")]
        public byte NumberOfPayments { get; set; }

        public InsuranceRequestInformationViewModel RequestInformation { get; set; }

        public List<MessageViewModel> Messages { get; set; }
    }
}
