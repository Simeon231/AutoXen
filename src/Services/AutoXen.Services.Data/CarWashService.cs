namespace AutoXen.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using AutoXen.Data.Common.Repositories;
    using AutoXen.Data.Models.CarWash;
    using AutoXen.Web.ViewModels.Administration.Requests;
    using AutoXen.Web.ViewModels.CarWash;
    using Microsoft.EntityFrameworkCore;

    public class CarWashService : ICarWashService
    {
        private readonly IRepository<CarWashRequest> carWashRequestRepository;
        private readonly IDeletableEntityRepository<CarWash> carWashRepository;
        private readonly ICarService carService;
        private readonly IMapper mapper;

        public CarWashService(
            IRepository<CarWashRequest> carWashRequestRepository,
            IDeletableEntityRepository<CarWash> carWashRepository,
            ICarService carService,
            IMapper mapper)
        {
            this.carWashRequestRepository = carWashRequestRepository;
            this.carWashRepository = carWashRepository;
            this.carService = carService;
            this.mapper = mapper;
        }

        public async Task AcceptAsync(string adminId, string requestId)
        {
            var request = this.carWashRequestRepository
                .All()
                .FirstOrDefault(x => x.Id == requestId);

            request.AcceptedById = adminId;

            await this.carWashRequestRepository.SaveChangesAsync();
        }

        public async Task AcceptAsync(AcceptViewModel model)
        {
            var request = this.carWashRequestRepository
                .All()
                .FirstOrDefault(x => x.Id == model.Id);

            request.AcceptedById = model.AdminId;

            await this.carWashRequestRepository.SaveChangesAsync();
        }

        /// <summary>
        /// <exception>Throws InvalidCarException.</exception>
        /// </summary>
        public async Task AddCarWashRequestAsync(CarWashRequestViewModel model, string userId)
        {
            this.carService.CheckUserHasCar(userId, model.CarId);

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

        public IEnumerable<CarWashRequest> GetAllRequests()
        {
            return this.carWashRequestRepository
                .AllAsNoTracking()
                .Include(x => x.User)
                .ToList();
        }

        public IEnumerable<CarWashRequest> GetAllRequestsById(string userId)
        {
            return this.carWashRequestRepository
                .AllAsNoTracking()
                .Include(x => x.Car)
                .Where(x => x.UserId == userId)
                .ToList();
        }
    }
}
