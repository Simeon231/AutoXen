namespace AutoXen.Services.Data
{
    using AutoXen.Web.ViewModels.Requests;

    public interface IRequestsService
    {
        public RequestsViewModel GetAll(UserFilterViewModel model, string userId, int itemsPerPage = 10);
    }
}
