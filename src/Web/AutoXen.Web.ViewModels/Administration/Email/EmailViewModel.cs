namespace AutoXen.Web.ViewModels.Administration.Email
{
    using System.ComponentModel.DataAnnotations;

    public class EmailViewModel
    {
        [Required]
        [MinLength(3)]
        public string Subject { get; set; }

        public string AdminId { get; set; }

        public string Message { get; set; }

        [Required]
        [EmailAddress]
        public string Receiver { get; set; }

        [Required]
        [Display(Name = "Request name")]
        public string RequestName { get; set; }

        [Required]
        public string RequestId { get; set; }
    }
}
