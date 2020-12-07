namespace AutoXen.Services.Data.Common
{
    using System.Threading.Tasks;

    using AutoXen.Web.ViewModels.Administration.Requests;

    public interface IBaseRequestService
    {
        public Task AcceptAsync(AcceptViewModel model);
    }
}
