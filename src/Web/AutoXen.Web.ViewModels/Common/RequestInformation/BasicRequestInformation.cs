namespace AutoXen.Web.ViewModels.Common.RequestInformation
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class BasicRequestInformation
    {
        [Display(Name = "Finished on")]
        public DateTime? FinishedOn { get; set; }
    }
}
