namespace AutoXen.Services.Data
{
    using System.Collections.Generic;

    using AutoXen.Web.ViewModels.Requests;

    public interface IRequestsService
    {
        public IEnumerable<RequestViewModel> GetAll(string userId);
    }
}
