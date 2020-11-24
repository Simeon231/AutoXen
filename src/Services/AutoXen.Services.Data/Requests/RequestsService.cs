namespace AutoXen.Services.Data.Requests
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AutoXen.Web.ViewModels.Requests;

    public class RequestsService : IRequestsService
    {
        public RequestsService()
        {

        }

        public IEnumerable<RequestViewModel> GetAll(string userId)
        {
            return null;
        }
    }
}
