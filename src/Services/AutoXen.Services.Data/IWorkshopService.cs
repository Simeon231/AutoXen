namespace AutoXen.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AutoXen.Data.Models.Workshop;
    using AutoXen.Services.Data.Common;
    using AutoXen.Web.ViewModels.Administration.Workshop;
    using AutoXen.Web.ViewModels.Workshop;

    public interface IWorkshopService : IBaseRequestService
    {
        /// <summary>
        /// <exception>Throws InvalidCarException.</exception>
        /// </summary>
        public Task AddWorkshopRequestAsync(WorkshopRequestViewModel model, string userId);

        public Task SubmitRequestAsync(WorkshopAdminViewModel model);

        public IEnumerable<WorkshopRequest> GetWorkshopRequestsByUserId(string userId);

        public IEnumerable<WorkshopRequest> GetAllRequests();

        public IEnumerable<ServiceWithPriceResponseModel> GetServicesByWorkshopId(int workshopId);

        public IEnumerable<ServiceResponseModel> GetAllServices();

        public IEnumerable<WorkshopViewModel> GetAllWorkshops();

        public WorkshopRequestDetailsViewModel GetWorkshopRequestDetails(string userId, string requestId, bool isAdmin = false);

        public IEnumerable<WorkshopServiceViewModel> GetWorkshopServicesByRequestId(string requestId);
    }
}
