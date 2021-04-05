namespace AutoXen.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using AutoXen.Data.Common.Repositories;
    using AutoXen.Data.Models.CarWash;
    using AutoXen.Web.ViewModels.Administration.CarWash;
    using AutoXen.Web.ViewModels.Administration.Requests;
    using AutoXen.Web.ViewModels.CarWash;
    using AutoXen.Web.ViewModels.Common;
    using Microsoft.EntityFrameworkCore;

    public class CarWashService : ICarWashService
    {
        private readonly IDeletableEntityRepository<CarWashRequest> carWashRequestRepository;
        private readonly IRepository<CarWash> carWashRepository;
        private readonly ICarService carService;
        private readonly IMessageService messageService;
        private readonly IMapper mapper;

        public CarWashService(
            IDeletableEntityRepository<CarWashRequest> carWashRequestRepository,
            IRepository<CarWash> carWashRepository,
            ICarService carService,
            IMessageService messageService,
            IMapper mapper)
        {
            this.carWashRequestRepository = carWashRequestRepository;
            this.carWashRepository = carWashRepository;
            this.carService = carService;
            this.messageService = messageService;
            this.mapper = mapper;
        }

        /// <summary>
        /// <exception>Throws InvalidCarException.</exception>
        /// </summary>
        public async Task AddCarWashRequestAsync(CarWashRequestViewModel model, string userId)
        {
            this.carService.CheckUserHaveACar(userId, model.CarId);

            if (model.PickUpFastAsPossible)
            {
                model.PickUpTime = null;
            }

            if (model.AdminChooseCarWash)
            {
                model.CarWashId = null;
            }

            var dbRequest = this.mapper.Map<CarWashRequest>(model);
            dbRequest.UserId = userId;
            await this.carWashRequestRepository.AddAsync(dbRequest);

            await this.carWashRequestRepository.SaveChangesAsync();

            if (model.Message != null)
            {
                var message = new MessageViewModel()
                {
                    IsAdmin = false,
                    RequestId = dbRequest.Id,
                    Text = model.Message,
                };

                await this.messageService.AddMessageAsync(message);
            }
        }

        public async Task SubmitRequestAsync(AdminCarWashDetailsViewModel model)
        {
            var carWashRequest = this.carWashRequestRepository
                .All()
                .FirstOrDefault(x => x.Id == model.Id);

            carWashRequest.CarWashId = model.CarWashId;
            carWashRequest.FinishedOn = model.RequestInformation.FinishedOn;
            carWashRequest.PickedUp = model.RequestInformation.PickedUp;
            carWashRequest.ServiceFinished = model.RequestInformation.ServiceFinished;
            carWashRequest.ReturnedCar = model.RequestInformation.ReturnedCar;
            carWashRequest.PickUpTime = model.PickUpTime;
            carWashRequest.PickUpLocation = model.PickUpLocation;
            carWashRequest.PickUpFastAsPossible = model.PickUpFastAsPossible;
            carWashRequest.ModifiedOn = DateTime.UtcNow;

            await this.carWashRequestRepository.SaveChangesAsync();
        }

        public CarWashRequestDetailsViewModel GetCarWashRequest(string userId, string requestId, bool isAdmin = false)
        {
            var dbRequest = this.carWashRequestRepository
                .AllWithDeleted()
                .Include(x => x.Car)
                .FirstOrDefault(x => x.Id == requestId && (x.UserId == userId || isAdmin));

            // TODO throw exception
            if (dbRequest == null)
            {
                return null;
            }

            var request = this.mapper.Map<CarWashRequestDetailsViewModel>(dbRequest);
            request.Messages = this.messageService.GetAllByRequestId(request.Id);

            return request;
        }

        public async Task AcceptAsync(AcceptViewModel model)
        {
            var request = this.carWashRequestRepository
                .All()
                .FirstOrDefault(x => x.Id == model.Id);

            if (request != null)
            {
                request.AcceptedById = model.AdminId;

                await this.carWashRequestRepository.SaveChangesAsync();
            }
        }

        public IEnumerable<CarWashViewModel> GetAllCarWashes()
        {
            return this.carWashRepository
                .AllAsNoTracking()
                .Select(x => new CarWashViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .ToList();
        }

        public IQueryable<CarWashRequest> GetAllRequests()
        {
            return this.carWashRequestRepository
                .AllAsNoTracking()
                .Include(x => x.User);
        }

        public IQueryable<CarWashRequest> GetAllRequestsByUserId(string userId)
        {
            return this.carWashRequestRepository
                .AllWithDeleted()
                .Include(x => x.Car)
                .Where(x => x.UserId == userId);
        }
    }
}
