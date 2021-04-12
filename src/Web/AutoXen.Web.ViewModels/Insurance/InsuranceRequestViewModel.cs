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
        public int InsurerId { get; set; }

        [Required]
        public IEnumerable<int> InsuranceIds { get; set; }

        [Required]
        public DateTime InsurenceStart { get; set; }

        [Required]
        public DateTime InsuranceEnd { get; set; }

        [Required]
        public byte NumberOfPayments { get; set; }

        public string Message { get; set; }
    }
}
