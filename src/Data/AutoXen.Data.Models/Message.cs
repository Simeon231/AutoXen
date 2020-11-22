namespace AutoXen.Data.Models
{
    using System;

    public class Message
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime SentOn { get; set; }

        public string SentById { get; set; }

        public string BaseRequestId { get; set; }

        public BaseRequest BaseRequest { get; set; }
    }
}
