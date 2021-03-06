﻿namespace AutoXen.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
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
        public Task AddCarWashRequestAsync(CarWashRequestViewModel model, string userId, bool isAdmin);

        public Task SubmitRequestAsync(AdminCarWashDetailsViewModel model);

        public CarWashRequestDetailsViewModel GetCarWashRequest(string userId, string requestId, bool isAdmin = false);

        public Task AcceptAsync(AcceptViewModel model);

        public IQueryable<CarWashRequest> GetAllRequestsByUserId(string userId);

        public IQueryable<CarWashRequest> GetAllRequests();
    }
}
