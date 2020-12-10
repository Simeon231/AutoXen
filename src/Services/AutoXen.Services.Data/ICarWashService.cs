namespace AutoXen.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AutoXen.Data.Models.CarWash;
    using AutoXen.Services.Data.Common;
    using AutoXen.Web.ViewModels.Administration.CarWash;
    using AutoXen.Web.ViewModels.CarWash;

    public interface ICarWashService : IBaseRequestService
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
    }
}
