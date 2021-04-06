namespace AutoXen.Services.Data.Administration
{
    using System.Threading.Tasks;

    using AutoXen.Web.ViewModels.Administration.Requests;

    public interface IRequestsAdminService
    {
        public RequestsViewModel GetAllRequests(AdminFilterViewModel model, string userId, int itemsPerPage = 10);

        public Task AcceptRequestAsync(AcceptViewModel model);
    }
}
