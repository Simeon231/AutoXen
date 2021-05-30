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
    using AutoXen.Services.Exceptions;
    using AutoXen.Web.ViewModels.Cars;

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

        public async Task AddCarAsync(string userId, DetailedCarViewModel model)
        {
            var dbCar = this.mapper.Map<Car>(model);
            await this.carRepository.AddAsync(dbCar);
            dbCar.UserId = userId;
            await this.ChangeCarExtrasAsync(dbCar.Id, model.CarExtraIds);

            await this.carRepository.SaveChangesAsync();
        }

        public IEnumerable<CarViewModel> GetAllCarsByUserId(string userId)
        {
            var cars = this.carRepository.AllAsNoTracking()
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.CreatedOn)
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

        public async Task ChangeCarDetailsAsync(DetailedCarViewModel model, string userId)
        {
            var dbCar = this.GetCar(model.Id, userId);

            this.mapper.Map(model, dbCar);

            await this.ChangeCarExtrasAsync(dbCar.Id, model.CarExtraIds);

            await this.carRepository.SaveChangesAsync();
        }

        public async Task DeleteCarAsync(string carId, string userId)
        {
            var dbCar = this.GetCar(carId, userId);

            this.carRepository.Delete(dbCar);
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

        public DetailedCarViewModel GetCarDetails(string carId, string userId)
        {
            var dbCar = this.GetCar(carId, userId);

            var car = this.mapper.Map<DetailedCarViewModel>(dbCar);
            car.CarExtraIds = this.GetExtras(dbCar.Id);

            return car;
        }

        /// <summary>
        /// <exception>Throws InvalidCarException.</exception>
        /// </summary>
        public void CheckUserHaveACar(string userId, string carId)
        {
            var car = this.carRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == carId && x.UserId == userId);

            if (car == null)
            {
                throw new InvalidCarException("Pick a valid car.");
            }
        }

        private Car GetCar(string carId, string userId)
        {
            var dbCar = this.carRepository.All().FirstOrDefault(x => x.Id == carId && x.UserId == userId);

            if (dbCar == null)
            {
                throw new WrongCarOwnerException();
            }

            return dbCar;
        }

        private IEnumerable<int> GetExtras(string carId)
        {
            return this.carExtraRepository.AllAsNoTracking().Where(x => x.CarId == carId).Select(x => x.ExtraId).ToList();
        }

        private async Task ChangeCarExtrasAsync(string carId, IEnumerable<int> extraIds)
        {
            if (extraIds == null)
            {
                return;
            }

            var dbExtras = this.carExtraRepository
                .All()
                .Where(x => x.CarId == carId)
                .ToList();

            // Remove extras
            foreach (var dbExtra in dbExtras)
            {
                if (!extraIds.Contains(dbExtra.ExtraId))
                {
                    this.carExtraRepository.Delete(dbExtra);
                }
            }

            // Add extras
            foreach (var extraId in extraIds)
            {
                var carExtra = new CarExtra()
                {
                    CarId = carId,
                    ExtraId = extraId,
                };

                if (!dbExtras.Any(x => x.ExtraId == carExtra.ExtraId))
                {
                    await this.carExtraRepository.AddAsync(carExtra);
                }
            }

            await this.carExtraRepository.SaveChangesAsync();
        }
    }
}
