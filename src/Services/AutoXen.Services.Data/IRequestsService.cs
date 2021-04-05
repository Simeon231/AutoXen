namespace AutoXen.Services.Data
{
    using AutoXen.Web.ViewModels.Requests;

    public interface IRequestsService
    {
        public RequestsViewModel GetAll(FilterViewModel model, string userId, int itemsPerPage = 10);
    }
}
