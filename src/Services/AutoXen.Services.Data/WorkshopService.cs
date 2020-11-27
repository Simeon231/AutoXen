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
        private readonly IRepository<WorkshopRequestWorkshopService> workshopRequestServiceRepository;
        private readonly IRepository<WorkshopRequestWService> workshopRequestWService;
        private readonly IDeletableEntityRepository<Car> carsRepository;
        private readonly IMapper mapper;

        public WorkshopService(
            IDeletableEntityRepository<WorkshopRequest> workshopRequestRepository,
            IRepository<WService> serviceRepository,
            IRepository<Workshop> workshopRepository,
            IRepository<AutoXen.Data.Models.Workshop.WorkshopService> workshopServiceRepository,
            IRepository<WorkshopRequestWorkshopService> workshopRequestServiceRepository,
            IRepository<WorkshopRequestWService> workshopRequestWService,
            IDeletableEntityRepository<Car> carsRepository,
            IMapper mapper)
        {
            this.workshopRequestRepository = workshopRequestRepository;
            this.serviceRepository = serviceRepository;
            this.workshopRepository = workshopRepository;
            this.workshopServiceRepository = workshopServiceRepository;
            this.workshopRequestServiceRepository = workshopRequestServiceRepository;
            this.workshopRequestWService = workshopRequestWService;
            this.carsRepository = carsRepository;
            this.mapper = mapper;
        }

        public async Task AddWorkshopRequestAsync(WorkshopRequestViewModel model, string userId)
        {
            var request = this.mapper.Map<WorkshopRequest>(model);
            request.UserId = userId;
            await this.workshopRequestRepository.AddAsync(request);
            await this.workshopRequestRepository.SaveChangesAsync();

            if (model.Ids != null && this.workshopRepository.AllAsNoTracking().Any(x => x.Id == model.WorkshopId))
            {
                foreach (var id in model.Ids)
                {
                    var requestServices = new WorkshopRequestWorkshopService()
                    {
                        WorkshopRequestId = request.Id,
                        WorkshopServiceId = id,
                    };

                    await this.workshopRequestServiceRepository.AddAsync(requestServices);
                }

                await this.workshopRequestServiceRepository.SaveChangesAsync();
            }
            else if (model.Ids != null)
            {
                foreach (var id in model.Ids)
                {
                    var requestWService = new WorkshopRequestWService()
                    {
                        WorkshopRequestId = request.Id,
                        WServiceId = id,
                    };

                    await this.workshopRequestWService.AddAsync(requestWService);
                }

                await this.workshopRequestWService.SaveChangesAsync();
            }
            else
            {
                // TODO throw exception
            }
        }

        public IEnumerable<WorkshopRequest> GetWorkshopRequests(string userId)
        {
            return this.workshopRequestRepository
                .AllAsNoTracking()
                .Include(x => x.Car)
                .Where(x => x.UserId == userId)
                .ToList();
        }

        public IEnumerable<WorkshopViewModel> GetAllWorkshops()
        {
            return this.workshopRepository
                .AllAsNoTracking()
                .Select(x => this.mapper.Map<WorkshopViewModel>(x))
                .ToList();
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
