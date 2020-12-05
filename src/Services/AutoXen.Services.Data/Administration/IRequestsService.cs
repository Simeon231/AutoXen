namespace AutoXen.Services.Data.Administration
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoXen.Web.ViewModels.Administration.Requests;

    public interface IRequestsService
    {
        public RequestsViewModel GetAllRequests(int page, int itemsPerPage = 10);

        public Task AcceptRequestAsync(string requestName, string requestId);
    }
}
