namespace AutoXen.Web.ViewModels.Common
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class MessageViewModel
    {
        [Required]
        public string Text { get; set; }

        public bool IsAdmin { get; set; }

        [Required]
        public string RequestId { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
