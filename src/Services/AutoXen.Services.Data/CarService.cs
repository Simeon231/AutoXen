namespace AutoXen.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using AutoXen.Data.Common.Repositories;
    using AutoXen.Data.Models.Car;
    using AutoXen.Data.Models.Enums;
    using AutoXen.Web.ViewModels;

    public class CarService : ICarService
    {
        private readonly IDeletableEntityRepository<Car> carRepository;
        private readonly IRepository<Extra> extraRepository;
        private readonly IRepository<CarExtra> carExtraRepository;
        private readonly IMapper mapper;

        public CarService(
            IDeletableEntityRepository<Car> carRepository,
            IRepository<Extra> extraRepository,
            IRepository<CarExtra> carExtraRepository,
            IMapper mapper)
        {
            this.carRepository = carRepository;
            this.extraRepository = extraRepository;
            this.carExtraRepository = carExtraRepository;
            this.mapper = mapper;
        }

        public async Task AddCarAsync(string userId, DetailedCarWithoutIdViewModel model)
        {
            var dbCar = this.mapper.Map<Car>(model);
            await this.carRepository.AddAsync(dbCar);
            dbCar.UserId = userId;
            await this.AddExtrasToDbAsync(dbCar.Id, model.CarExtras);

            await this.carRepository.SaveChangesAsync();
        }

        public IEnumerable<CarViewModel> AllCars(string userId)
        {
            var cars = this.carRepository.AllAsNoTracking()
                .Where(x => x.UserId == userId)
                .OrderBy(x => x.CreatedOn)
                .Select(x => this.mapper.Map<CarViewModel>(x))
                .ToList();

            return cars;
        }

        public IEnumerable<ExtraViewModel> GetAllExtras()
        {
            return this.extraRepository.AllAsNoTracking()
                .Select(x => new ExtraViewModel()
                {
                    Name = x.Name,
                    Id = x.Id,
                })
                .ToList();
        }

        public async Task ChangeCarDetailsAsync(DetailedCarWithIdViewModel model)
        {
            var car = this.carRepository.All().FirstOrDefault(x => x.Id == model.Id);

            this.mapper.Map(model, car);
            await this.AddExtrasToDbAsync(car.Id, model.CarExtras);

            await this.carRepository.SaveChangesAsync();
        }

        public async Task Delete(string carId)
        {
            var car = this.carRepository.All().FirstOrDefault(x => x.Id == carId);

            this.carRepository.Delete(car);
            await this.carRepository.SaveChangesAsync();
        }

        public List<string> GetAllTransmissionTypes()
        {
            var fuelTypes = new List<string>();
            foreach (int i in Enum.GetValues(typeof(TransmissionType)))
            {
                var name = Enum.GetName(typeof(TransmissionType), i);
                fuelTypes.Add(name);
            }

            return fuelTypes;
        }

        public List<string> GetAllFuelTypes()
        {
            var fuelTypes = new List<string>();
            foreach (int i in Enum.GetValues(typeof(FuelType)))
            {
                var name = Enum.GetName(typeof(FuelType), i);
                fuelTypes.Add(name);
            }

            return fuelTypes;
        }

        public DetailedCarWithoutIdViewModel GetCarDetails(string carId)
        {
            var dbCar = this.carRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == carId);

            var car = this.mapper.Map<DetailedCarWithIdViewModel>(dbCar);
            car.CarExtras = this.GetExtras(dbCar.Id);

            return car;
        }

        private IEnumerable<int> GetExtras(string carId)
        {
            return this.carExtraRepository.AllAsNoTracking().Where(x => x.CarId == carId).Select(x => x.ExtraId).ToList();
        }

        private async Task AddExtrasToDbAsync(string carId, IEnumerable<int> extras)
        {
            if (extras == null)
            {
                return;
            }

            foreach (var extra in extras)
            {
                var carExtra = new CarExtra()
                {
                    CarId = carId,
                    ExtraId = extra,
                };

                await this.carExtraRepository.AddAsync(carExtra);
            }
        }
    }
}
