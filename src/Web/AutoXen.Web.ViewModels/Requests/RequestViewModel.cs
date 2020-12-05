namespace AutoXen.Web.ViewModels.Requests
{
    using System;

    using AutoXen.Web.ViewModels.Cars;

    public class RequestViewModel
    {
        public CarViewModel Car { get; set; }

        public string Id { get; set; }

        public string RequestName { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
