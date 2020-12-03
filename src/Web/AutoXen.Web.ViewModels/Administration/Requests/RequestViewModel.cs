namespace AutoXen.Web.ViewModels.Administration.Requests
{
    using AutoXen.Web.ViewModels.User;
    using System;

    public class RequestViewModel
    {
        public UserViewModel User { get; set; }

        public string Id { get; set; }

        public string RequestName { get; set; }

        public DateTime CreatedOn { get; set; }

        public string AcceptedById { get; set; }
    }
}
