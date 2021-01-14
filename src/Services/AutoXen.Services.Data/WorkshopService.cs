namespace AutoXen.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using AutoXen.Data.Common.Repositories;
    using AutoXen.Data.Models.Workshop;
    using AutoXen.Web.ViewModels.Administration.Requests;
    using AutoXen.Web.ViewModels.Administration.Workshop;
    using AutoXen.Web.ViewModels.Common;
    using AutoXen.Web.ViewModels.Workshop;
    using Microsoft.EntityFrameworkCore;

    public class WorkshopService : IWorkshopService
    {
        private readonly IDeletableEntityRepository<WorkshopRequest> workshopRequestRepository;
        private readonly IRepository<WService> serviceRepository;
        private readonly IRepository<Workshop> workshopRepository;
        private readonly IRepository<AutoXen.Data.Models.Workshop.WorkshopService> workshopServiceRepository;
        private readonly IRepository<WorkshopRequestWorkshopService> workshopRequestWorkshopServiceRepository;
        private readonly IRepository<WorkshopRequestWService> workshopRequestWServiceRepository;
        private readonly IMessageService messageService;
        private readonly ICarService carService;
        private readonly IMapper mapper;

        public WorkshopService(
            IDeletableEntityRepository<WorkshopRequest> workshopRequestRepository,
            IRepository<WService> serviceRepository,
            IRepository<Workshop> workshopRepository,
            IRepository<AutoXen.Data.Models.Workshop.WorkshopService> workshopServiceRepository,
            IRepository<WorkshopRequestWorkshopService> workshopRequestWorkshopServiceRepository,
            IRepository<WorkshopRequestWService> workshopRequestWService,
            IMessageService messageService,
            ICarService carService,
            IMapper mapper)
        {
            this.workshopRequestRepository = workshopRequestRepository;
            this.serviceRepository = serviceRepository;
            this.workshopRepository = workshopRepository;
            this.workshopServiceRepository = workshopServiceRepository;
            this.workshopRequestWorkshopServiceRepository = workshopRequestWorkshopServiceRepository;
            this.workshopRequestWServiceRepository = workshopRequestWService;
            this.messageService = messageService;
            this.carService = carService;
            this.mapper = mapper;
        }

        /// <summary>
        /// <exception>Throws InvalidCarException.</exception>
        /// </summary>
        public async Task AddWorkshopRequestAsync(WorkshopRequestViewModel model, string userId)
        {
            this.carService.CheckUserHaveACar(userId, model.CarId);

            var request = this.mapper.Map<WorkshopRequest>(model);
            request.UserId = userId;
            await this.workshopRequestRepository.AddAsync(request);

            if (model.Ids != null && model.WorkshopId > 0)
            {
                await this.AddWorkshopServicesAsync(request.Id, model.Ids);
            }
            else if (model.Ids != null)
            {
                // Add WServices
                foreach (var id in model.Ids)
                {
                    var requestWService = new WorkshopRequestWService()
                    {
                        WorkshopRequestId = request.Id,
                        WServiceId = id,
                    };

                    await this.workshopRequestWServiceRepository.AddAsync(requestWService);
                }

                await this.workshopRequestWServiceRepository.SaveChangesAsync();
            }

            await this.workshopRequestRepository.SaveChangesAsync();

            if (model.Message != null)
            {
                var message = new MessageViewModel()
                {
                    IsAdmin = false,
                    RequestId = request.Id,
                    Text = model.Message,
                };

                await this.messageService.AddMessageAsync(message);
            }
        }

        public IEnumerable<WorkshopRequest> GetWorkshopRequestsByUserId(string userId)
        {
            return this.workshopRequestRepository
                .AllAsNoTracking()
                .Include(x => x.Car)
                .Where(x => x.UserId == userId)
                .ToList();
        }

        public WorkshopRequestDetailsViewModel GetWorkshopRequestDetails(string userId, string requestId, bool isAdmin = false)
        {
            var dbRequest = this.workshopRequestRepository
                .AllWithDeleted()
                .Include(x => x.Car)
                .FirstOrDefault(x => x.Id == requestId && (x.UserId == userId || isAdmin));

            // TODO throw exception
            if (dbRequest == null)
            {
                return null;
            }

            var request = this.mapper.Map<WorkshopRequestDetailsViewModel>(dbRequest);

            var requestWorkshopService = this.workshopRequestWorkshopServiceRepository
                .AllAsNoTracking()
                .Include(x => x.WorkshopService.Workshop)
                .FirstOrDefault(x => x.WorkshopRequestId == dbRequest.Id);

            if (dbRequest.AdminChooseWorkshop &&
                requestWorkshopService == null)
            {
                request.WServices = this.workshopRequestWServiceRepository
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
                    .Select(x => x.WorkshopService.Id)
                    .ToList();

                request.Workshop = this.mapper.Map<WorkshopViewModel>(requestWorkshopService.WorkshopService.Workshop);
            }

            request.Messages = this.messageService.GetAllByRequestId(requestId);

            return request;
        }

        public async Task SubmitRequestAsync(WorkshopAdminViewModel model)
        {
            var request = this.workshopRequestRepository
                .All()
                .FirstOrDefault(x => x.Id == model.Id);

            request.ServiceFinished = model.RequestInformation.ServiceFinished;
            request.ReturnedCar = model.RequestInformation.ReturnedCar;
            request.PickedUp = model.RequestInformation.PickedUp;
            request.FinishedOn = model.RequestInformation.FinishedOn;
            request.OtherServices = model.OtherServices;
            request.PickUpLocation = model.PickUpLocation;
            request.PickUpTime = model.PickUpTime;
            request.PickUpFastAsPossible = model.PickUpFastAsPossible;
            request.ModifiedOn = DateTime.UtcNow;

            await this.AddWorkshopServicesAsync(request.Id, model.ServiceIds);

            await this.workshopRequestRepository.SaveChangesAsync();
        }

        public IEnumerable<WorkshopViewModel> GetAllWorkshops()
        {
            return this.workshopRepository
                .AllAsNoTracking()
                .Select(x => this.mapper.Map<WorkshopViewModel>(x))
                .ToList();
        }

        public IEnumerable<ServiceResponseModel> GetAllServices()
        {
            return this.serviceRepository
                .AllAsNoTracking()
                .Select(x => this.mapper.Map<ServiceResponseModel>(x))
                .ToList();
        }

        // TODO Decide what to do with this method and in admin details
        public IEnumerable<WorkshopServiceViewModel> GetWorkshopServicesByRequestId(string requestId)
        {
            return this.workshopRequestWorkshopServiceRepository
                    .AllAsNoTracking()
                    .Where(x => x.WorkshopRequestId == requestId)
                    .Include(x => x.WorkshopService.Service)
                    .Select(x => this.mapper.Map<WorkshopServiceViewModel>(x.WorkshopService))
                    .ToList();
        }

        public IEnumerable<int> GetWorkshopServicesIdsByRequestId(string requestId)
        {
            return this.workshopRequestWorkshopServiceRepository
                    .AllAsNoTracking()
                    .Where(x => x.WorkshopRequestId == requestId)
                    .Select(x => x.Id)
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

        public IEnumerable<WorkshopRequest> GetAllRequests()
        {
            return this.workshopRequestRepository
                .AllAsNoTracking()
                .Include(x => x.User)
                .ToList();
        }

        public async Task AcceptAsync(AcceptViewModel model)
        {
            var request = this.workshopRequestRepository
                .All()
                .FirstOrDefault(x => x.Id == model.Id);

            request.AcceptedById = model.AdminId;

            await this.workshopRequestRepository.SaveChangesAsync();
        }

        private async Task AddWorkshopServicesAsync(string requestId, IEnumerable<int> serviceIds)
        {
            var workshopRequestWorkshopServices = this.workshopRequestWorkshopServiceRepository.AllAsNoTracking().Where(x => x.WorkshopRequestId == requestId).ToList();

            // remove all
            if (serviceIds == null)
            {
                foreach (var workshopRequestWorkshopService in workshopRequestWorkshopServices)
                {
                    this.workshopRequestWorkshopServiceRepository.Delete(workshopRequestWorkshopService);
                }

                await this.workshopRequestWorkshopServiceRepository.SaveChangesAsync();

                return;
            }

            // add
            foreach (var id in serviceIds)
            {
                var workshopService = this.workshopServiceRepository
                    .AllAsNoTracking()
                    .FirstOrDefault(x => x.Id == id);

                if (workshopService != null && !workshopRequestWorkshopServices.Any(x => x.WorkshopServiceId == workshopService.Id))
                {
                    var requestServices = new WorkshopRequestWorkshopService()
                    {
                        WorkshopRequestId = requestId,
                        WorkshopServiceId = workshopService.Id,
                    };

                    await this.workshopRequestWorkshopServiceRepository.AddAsync(requestServices);
                }
            }

            // remove
            foreach (var workshopRequestWorkshopService in workshopRequestWorkshopServices)
            {
                if (!serviceIds.Any(x => x == workshopRequestWorkshopService.WorkshopServiceId))
                {
                    this.workshopRequestWorkshopServiceRepository.Delete(workshopRequestWorkshopService);
                }
            }

            await this.workshopRequestWorkshopServiceRepository.SaveChangesAsync();
        }
    }
}
