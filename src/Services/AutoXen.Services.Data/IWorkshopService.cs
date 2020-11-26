namespace AutoXen.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AutoXen.Web.ViewModels.Workshop;

    public interface IWorkshopService
    {
        public Task AddWorkshopRequestAsync(WorkshopRequestViewModel model);

        public WorkshopRequestViewModel GetWorkshopServices(string userId);

        public IEnumerable<ServiceWithPriceResponseModel> GetServicesByWorkshopId(int workshopId);

        public IEnumerable<ServiceModel> GetAllServices();
    }
}
