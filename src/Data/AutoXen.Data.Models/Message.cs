﻿namespace AutoXen.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using AutoXen.Data.Common.Models;

    public class Message : BaseModel<int>
    {
        [Required]
        public string Text { get; set; }

        public bool IsAdmin { get; set; }

        [Required]
        public string RequestId { get; set; }
    }
}
