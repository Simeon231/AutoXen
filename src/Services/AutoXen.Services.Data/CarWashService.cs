namespace AutoXen.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using AutoXen.Data;
    using AutoXen.Data.Common.Repositories;
    using AutoXen.Data.Models;
    using AutoXen.Data.Models.CarWash;
    using AutoXen.Web.ViewModels;

    public class CarWashService : ICarWashService
    {
        private readonly IRepository<CarWashRequest> carWashRequestRepository;
        private readonly IDeletableEntityRepository<CarWash> carWashRepository;
        private readonly IMapper mapper;

        public CarWashService(
            IRepository<CarWashRequest> carWashRequestRepository,
            IDeletableEntityRepository<CarWash> carWashRepository,
            IMapper mapper)
        {
            this.carWashRequestRepository = carWashRequestRepository;
            this.carWashRepository = carWashRepository;
            this.mapper = mapper;
        }

        public async Task AddCarWashRequestAsync(CarWashRequestViewModel model, string userId)
        {
            if (model.PickUpFastAsPossible)
            {
                model.PickUpTime = null;
            }

            if (model.AdminChooseCarWash)
            {
                model.CarWashId = null;
            }

            var dbRequest = this.mapper.Map<CarWashRequest>(model);
            dbRequest.BaseRequest.CarId = model.CarId;
            dbRequest.BaseRequest.UserId = userId;
            dbRequest.BaseRequest.RequestName = Data.Enums.RequestName.CarWash;
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

        public IEnumerable<CarWashRequestViewModel> GetAllRequests(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
