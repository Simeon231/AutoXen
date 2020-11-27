namespace AutoXen.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using AutoXen.Data.Common.Repositories;
    using AutoXen.Data.Models.Car;
    using AutoXen.Data.Models.CarWash;
    using AutoXen.Web.ViewModels;
    using Microsoft.EntityFrameworkCore;

    public class CarWashService : ICarWashService
    {
        private readonly IRepository<CarWashRequest> carWashRequestRepository;
        private readonly IDeletableEntityRepository<CarWash> carWashRepository;
        private readonly IDeletableEntityRepository<Car> carRepository;
        private readonly IMapper mapper;

        public CarWashService(
            IRepository<CarWashRequest> carWashRequestRepository,
            IDeletableEntityRepository<CarWash> carWashRepository,
            IDeletableEntityRepository<Car> carRepository,
            IMapper mapper)
        {
            this.carWashRequestRepository = carWashRequestRepository;
            this.carWashRepository = carWashRepository;
            this.carRepository = carRepository;
            this.mapper = mapper;
        }

        public async Task AddCarWashRequestAsync(CarWashRequestViewModel model, string userId)
        {
            var car = this.carRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == model.CarId);

            if (car == null)
            {
                throw new NullReferenceException("Invalid car");
            }

            if (model.PickUp.FastAsPossible)
            {
                model.PickUp.Time = null;
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

        public IEnumerable<CarWashRequest> GetAllRequests(string userId)
        {
            return this.carWashRequestRepository
                .AllAsNoTracking()
                .Include(x => x.Car)
                .Where(x => x.UserId == userId)
                .ToList();
        }
    }
}
