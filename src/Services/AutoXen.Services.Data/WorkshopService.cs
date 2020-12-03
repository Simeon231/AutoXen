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
        private readonly IRepository<WorkshopRequestWorkshopService> workshopRequestWorkshopServiceRepository;
        private readonly IRepository<WorkshopRequestWService> workshopRequestWService;
        private readonly ICarService carService;
        private readonly IMapper mapper;

        public WorkshopService(
            IDeletableEntityRepository<WorkshopRequest> workshopRequestRepository,
            IRepository<WService> serviceRepository,
            IRepository<Workshop> workshopRepository,
            IRepository<AutoXen.Data.Models.Workshop.WorkshopService> workshopServiceRepository,
            IRepository<WorkshopRequestWorkshopService> workshopRequestWorkshopServiceRepository,
            IRepository<WorkshopRequestWService> workshopRequestWService,
            ICarService carService,
            IMapper mapper)
        {
            this.workshopRequestRepository = workshopRequestRepository;
            this.serviceRepository = serviceRepository;
            this.workshopRepository = workshopRepository;
            this.workshopServiceRepository = workshopServiceRepository;
            this.workshopRequestWorkshopServiceRepository = workshopRequestWorkshopServiceRepository;
            this.workshopRequestWService = workshopRequestWService;
            this.carService = carService;
            this.mapper = mapper;
        }

        /// <summary>
        /// <exception>Throws InvalidCarException.</exception>
        /// </summary>
        public async Task AddWorkshopRequestAsync(WorkshopRequestViewModel model, string userId)
        {
            this.carService.CheckUserHasCar(userId, model.CarId);

            var request = this.mapper.Map<WorkshopRequest>(model);
            request.UserId = userId;
            await this.workshopRequestRepository.AddAsync(request);

            if (model.Ids != null && this.workshopRepository.AllAsNoTracking().Any(x => x.Id == model.WorkshopId))
            {
                foreach (var id in model.Ids)
                {
                    var requestServices = new WorkshopRequestWorkshopService()
                    {
                        WorkshopRequestId = request.Id,
                        WorkshopServiceId = id,
                    };

                    await this.workshopRequestWorkshopServiceRepository.AddAsync(requestServices);
                }

                await this.workshopRequestWorkshopServiceRepository.SaveChangesAsync();
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

            await this.workshopRequestRepository.SaveChangesAsync();
        }

        public IEnumerable<WorkshopRequest> GetWorkshopRequestsById(string userId)
        {
            return this.workshopRequestRepository
                .AllAsNoTracking()
                .Include(x => x.Car)
                .Where(x => x.UserId == userId)
                .ToList();
        }

        public IEnumerable<WorkshopRequest> GetAllRequests()
        {
            return this.workshopRequestRepository
                .AllAsNoTracking()
                .Include(x => x.User)
                .ToList();
        }

        public WorkshopRequestDetailsViewModel GetWorkshopDetails(string userId, string requestId)
        {
            var dbRequest = this.workshopRequestRepository
                .AllAsNoTracking()
                .Include(x => x.Car)
                .Include(x => x.WorkshopRequestWorkshopServices)
                .FirstOrDefault(x => x.UserId == userId && x.Id == requestId);

            var request = this.mapper.Map<WorkshopRequestDetailsViewModel>(dbRequest);

            if (dbRequest.AdminChooseWorkshop)
            {
                request.WServices = this.workshopRequestWService
                    .AllAsNoTracking()
                    .Include(x => x.WService)
                    .Where(x => x.WorkshopRequestId == dbRequest.Id)
                    .Select(x => this.mapper.Map<WServiceViewModel>(x.WService))
                    .ToList();
            }
            else
            {
                request.WorkshopServices = this.workshopRequestWorkshopServiceRepository
                    .AllAsNoTracking()
                    .Where(x => x.WorkshopRequestId == dbRequest.Id)
                    .Include(x => x.WorkshopService.Service)
                    .Select(x => this.mapper.Map<WorkshopServiceViewModel>(x.WorkshopService))
                    .ToList();

                var dbWorkshopService = this.workshopRequestWorkshopServiceRepository
                    .AllAsNoTracking()
                    .Include(x => x.WorkshopService.Workshop)
                    .FirstOrDefault(x => x.WorkshopRequestId == dbRequest.Id).WorkshopService.Workshop;

                request.Workshop = this.mapper.Map<WorkshopViewModel>(dbWorkshopService);
            }

            return request;
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
