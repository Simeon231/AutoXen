namespace AutoXen.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AutoXen.Web.ViewModels;

    public interface ICarWashService
    {
        public IEnumerable<CarWashViewModel> GetAllCarWashes();

        public Task AddCarWashRequestAsync(CarWashRequestViewModel model, string userId);

        public IEnumerable<CarWashRequestViewModel> GetAllRequests(string userId);
    }
}
