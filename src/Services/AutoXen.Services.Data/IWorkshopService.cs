namespace AutoXen.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoXen.Data.Models.Workshop;
    using AutoXen.Web.ViewModels.Administration.Requests;
    using AutoXen.Web.ViewModels.Administration.Workshop;
    using AutoXen.Web.ViewModels.Workshop;

    public interface IWorkshopService
    {
        /// <summary>
        /// <exception>Throws InvalidCarException.</exception>
        /// </summary>
        public Task AddWorkshopRequestAsync(WorkshopRequestViewModel model, string userId, bool isAdmin);

        public Task SubmitRequestAsync(WorkshopAdminViewModel model);

        public IEnumerable<ServiceWithPriceResponseModel> GetServicesByWorkshopId(int workshopId);

        public IEnumerable<ServiceResponseModel> GetAllServices();

        public IEnumerable<WorkshopViewModel> GetAllWorkshops();

        public WorkshopRequestDetailsViewModel GetWorkshopRequestDetails(string userId, string requestId, bool isAdmin = false);

        public IEnumerable<WorkshopServiceViewModel> GetWorkshopServicesByRequestId(string requestId);

        public IEnumerable<int> GetWorkshopServicesIdsByRequestId(string requestId);

        public Task AcceptAsync(AcceptViewModel model);

        public IQueryable<WorkshopRequest> GetAllRequestsByUserId(string userId);

        public IQueryable<WorkshopRequest> GetAllRequests();
    }
}
