namespace AutoXen.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AutoXen.Data.Models.CarWash;
    using AutoXen.Web.ViewModels;

    public interface ICarWashService
    {
        public IEnumerable<CarWashViewModel> GetAllCarWashes();

        /// <summary>
        /// <exception>Throws InvalidCarException.</exception>
        /// </summary>
        public Task AddCarWashRequestAsync(CarWashRequestViewModel model, string userId);

        public IEnumerable<CarWashRequest> GetAllRequestsById(string userId);

        public IEnumerable<CarWashRequest> GetAllRequests();
    }
}
