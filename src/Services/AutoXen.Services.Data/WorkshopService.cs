namespace AutoXen.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using AutoXen.Data.Common.Repositories;
    using AutoXen.Data.Models.Car;
    using AutoXen.Data.Models.Workshop;
    using AutoXen.Web.ViewModels;
    using AutoXen.Web.ViewModels.Workshop;
    using Microsoft.EntityFrameworkCore;

    public class WorkshopService : IWorkshopService
    {
        private readonly IDeletableEntityRepository<WorkshopRequest> workshopRequestRepository;
        private readonly IRepository<WService> serviceRepository;
        private readonly IRepository<Workshop> workshopRepository;
        private readonly IRepository<AutoXen.Data.Models.Workshop.WorkshopService> workshopServiceRepository;
        private readonly IRepository<WorkshopRequestServices> workshopRequestServicesRepository;
        private readonly IDeletableEntityRepository<Car> carsRepository;
        private readonly IMapper mapper;

        public WorkshopService(
            IDeletableEntityRepository<WorkshopRequest> workshopRequestRepository,
            IRepository<WService> serviceRepository,
            IRepository<Workshop> workshopRepository,
            IRepository<AutoXen.Data.Models.Workshop.WorkshopService> workshopServiceRepository,
            IRepository<WorkshopRequestServices> workshopRequestServicesRepository,
            IDeletableEntityRepository<Car> carsRepository,
            IMapper mapper)
        {
            this.workshopRequestRepository = workshopRequestRepository;
            this.serviceRepository = serviceRepository;
            this.workshopRepository = workshopRepository;
            this.workshopServiceRepository = workshopServiceRepository;
            this.workshopRequestServicesRepository = workshopRequestServicesRepository;
            this.carsRepository = carsRepository;
            this.mapper = mapper;
        }

        public Task AddWorkshopRequestAsync(WorkshopRequestViewModel model)
        {
            throw new NotImplementedException();
        }

        public WorkshopRequestViewModel GetWorkshopServices(string userId)
        {
            var viewModel = new WorkshopRequestViewModel
            {
                WorkshopsServices = this.workshopServiceRepository
                .AllAsNoTracking()
                .Include(x => x.Workshop)
                .Include(x => x.Service)
                .Select(x => this.mapper.Map<WorkshopServiceViewModel>(x))
                .ToList(),

                Cars = this.carsRepository
                .AllAsNoTracking()
                .Where(x => x.UserId == userId)
                .Select(x => this.mapper.Map<CarViewModel>(x))
                .ToList(),

                Workshops = this.workshopRepository
                .AllAsNoTracking()
                .Select(x => this.mapper.Map<WorkshopViewModel>(x))
                .ToList(),

                Services = this.GetAllServices(),
            };

            return viewModel;
        }

        public IEnumerable<ServiceModel> GetAllServices()
        {
            return this.serviceRepository
                .AllAsNoTracking()
                .Select(x => this.mapper.Map<ServiceModel>(x))
                .ToList();
        }

        public IEnumerable<ServiceWithPriceResponseModel> GetServicesByWorkshopId(int workshopId)
        {
            return this.workshopServiceRepository
                .AllAsNoTracking()
                .Include(x => x.Service)
                .Where(x => x.WorkshopId == workshopId)
                .Select(x => this.mapper.Map<ServiceWithPriceResponseModel>(x))
                .ToList();
        }
    }
}
