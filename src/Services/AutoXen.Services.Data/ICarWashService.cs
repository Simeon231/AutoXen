namespace AutoXen.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AutoXen.Data.Models.CarWash;
    using AutoXen.Web.ViewModels.Administration.CarWash;
    using AutoXen.Web.ViewModels.Administration.Requests;
    using AutoXen.Web.ViewModels.CarWash;

    public interface ICarWashService
    {
        public IEnumerable<CarWashViewModel> GetAllCarWashes();

        /// <summary>
        /// <exception>Throws InvalidCarException.</exception>
        /// </summary>
        public Task AddCarWashRequestAsync(CarWashRequestViewModel model, string userId);

        public Task SubmitRequestAsync(AdminCarWashDetailsViewModel model);

        public CarWashRequestDetailsViewModel GetCarWashRequest(string userId, string requestId, bool isAdmin = false);

        public IEnumerable<CarWashRequest> GetAllRequestsById(string userId);

        public IEnumerable<CarWashRequest> GetAllRequests();

        public Task AcceptAsync(AcceptViewModel model);
    }
}
