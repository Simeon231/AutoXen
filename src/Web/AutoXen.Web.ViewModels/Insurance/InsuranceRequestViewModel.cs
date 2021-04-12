namespace AutoXen.Web.ViewModels.Insurance
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class InsuranceRequestViewModel
    {
        [Required]
        public string CarId { get; set; }

        [Required]
        [Display(Name = "Company")]
        public int InsurerId { get; set; }

        [Required]
        [Display(Name = "Insurances")]
        public IEnumerable<int> InsuranceIds { get; set; }

        [Required]
        [Display(Name = "StartDate")]
        public DateTime InsurenceStart { get; set; }

        [Required]
        [Display(Name = "EndDate")]
        public DateTime InsuranceEnd { get; set; }

        [Required]
        [Display(Name = "Payments")]
        public byte NumberOfPayments { get; set; }

        [Display(Name = "Message")]
        public string Message { get; set; }
    }
}
