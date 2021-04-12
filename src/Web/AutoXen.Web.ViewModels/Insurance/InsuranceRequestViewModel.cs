namespace AutoXen.Web.ViewModels.Insurance
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class InsuranceRequestViewModel
    {
        [Required(ErrorMessage = "CarError")]
        public string CarId { get; set; }

        [Required(ErrorMessage = "CompanyError")]
        [Display(Name = "Company")]
        public int InsurerId { get; set; }

        [Required(ErrorMessage = "InsurancesError")]
        [Display(Name = "Insurances")]
        public IEnumerable<int> InsuranceIds { get; set; }

        [Required(ErrorMessage = "StartDateError")]
        [Display(Name = "StartDate")]
        public DateTime InsurenceStart { get; set; }

        [Required(ErrorMessage = "EndDateError")]
        [Display(Name = "EndDate")]
        public DateTime InsuranceEnd { get; set; }

        [Required(ErrorMessage = "NumberOfPaymentsError")]
        [Display(Name = "Payments")]
        public byte NumberOfPayments { get; set; }

        [Display(Name = "Message")]
        public string Message { get; set; }
    }
}
