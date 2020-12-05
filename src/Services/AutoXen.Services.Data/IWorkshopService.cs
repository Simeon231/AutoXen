﻿namespace AutoXen.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AutoXen.Data.Models.Workshop;
    using AutoXen.Web.ViewModels.Workshop;

    public interface IWorkshopService
    {
        /// <summary>
        /// <exception>Throws InvalidCarException.</exception>
        /// </summary>
        public Task AddWorkshopRequestAsync(WorkshopRequestViewModel model, string userId);

        public IEnumerable<WorkshopRequest> GetWorkshopRequestsById(string userId);

        public IEnumerable<WorkshopRequest> GetAllRequests();

        public IEnumerable<ServiceWithPriceResponseModel> GetServicesByWorkshopId(int workshopId);

        public IEnumerable<ServiceResponseModel> GetAllServices();

        public IEnumerable<WorkshopViewModel> GetAllWorkshops();

        public WorkshopRequestDetailsViewModel GetWorkshopDetails(string userId, string requestId, bool isAdmin = false);

        public Task AcceptAsync(string adminId, string requestId);
    }
}
