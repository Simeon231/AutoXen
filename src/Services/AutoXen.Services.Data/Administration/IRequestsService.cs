namespace AutoXen.Services.Data.Administration
{
    using System.Collections.Generic;

    using AutoXen.Web.ViewModels.Administration.Requests;

    public interface IRequestsService
    {
        public IEnumerable<RequestViewModel> GetAllRequests();
    }
}
