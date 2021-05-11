namespace AutoXen.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using AutoXen.Data.Common.Repositories;
    using AutoXen.Data.Models.Car;
    using AutoXen.Data.Models.Enums;
    using AutoXen.Services.Data.Exceptions;
    using AutoXen.Web.Infrastructure.Profiles;
    using AutoXen.Web.ViewModels.Cars;
    using Moq;
    using Xunit;

    public class CarServiceTests
    {
        private readonly Mock<IDeletableEntityRepository<Car>> carRepository;
        private readonly Mock<IRepository<Extra>> extraRepository;
        private readonly Mock<IRepository<CarExtra>> carExtraRepository;
        private readonly IMapper mapper;
        private readonly int carsCount = 3;

        public CarServiceTests()
        {
            this.carRepository = new Mock<IDeletableEntityRepository<Car>>();
            this.extraRepository = new Mock<IRepository<Extra>>();
            this.carExtraRepository = new Mock<IRepository<CarExtra>>();
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CarProfile());
            });
            this.mapper = mockMapper.CreateMapper();
        }

        [Fact]
        public async Task AddCarAsyncShouldAddACarSuccessfully()
        {
            var carService = new CarService(this.carRepository.Object, this.extraRepository.Object, this.carExtraRepository.Object, this.mapper);
            var car = new Car();

            this.carRepository.Setup(x => x.AddAsync(It.IsAny<Car>()))
                .Callback((Car c) => car = c);

            var carModel = new DetailedCarViewModel()
            {
                Brand = "Brand",
                Model = "Model",
                Color = "Red",
                FuelType = FuelType.Diesel,
                Weight = 1000,
                NumberOfSeats = 4,
                RegistrationPlate = "PK4200PP",
                TransmissionType = TransmissionType.Automated,
                YearMade = 2005,
                VehicleIdentificationNumber = "1234567890abcdefg",
            };

            await carService.AddCarAsync("user1", carModel);

            Assert.Equal(carModel.Brand, car.Brand);
            Assert.Equal(carModel.Color, car.Color);
            Assert.Equal(carModel.FuelType, car.FuelType);
            Assert.Equal(carModel.Model, car.Model);
            Assert.Equal(carModel.NumberOfSeats, car.NumberOfSeats);
            Assert.Equal(carModel.RegistrationPlate, car.RegistrationPlate);
            Assert.Equal(carModel.TransmissionType, car.TransmissionType);
            Assert.Equal(carModel.VehicleIdentificationNumber, car.VehicleIdentificationNumber);
            Assert.Equal(carModel.Weight, car.Weight);
            Assert.Equal(carModel.YearMade, car.YearMade);
        }

        [Fact]
        public void AllCarsShouldReturnAllCars()
        {
            var carService = new CarService(this.carRepository.Object, this.extraRepository.Object, this.carExtraRepository.Object, this.mapper);
            var cars = this.GetCars();

            this.carRepository.Setup(x => x.AllAsNoTracking())
                .Returns(cars.AsQueryable());

            var usersCars = carService.GetAllCarsByUserId("user1");

            Assert.Single(usersCars);
        }

        [Fact]
        public async Task ChangeCarDetailsAsyncShouldChangeCarSuccessfully()
        {
            var carService = new CarService(this.carRepository.Object, this.extraRepository.Object, this.carExtraRepository.Object, this.mapper);
            var car = new Car();

            this.carRepository.Setup(x => x.AddAsync(It.IsAny<Car>()))
                .Callback((Car c) => car = c);

            var carModel = await this.AddCarAsync(carService);

            var cars = new List<Car>() { car };
            this.carRepository.Setup(x => x.All())
                .Returns(cars.AsQueryable());

            carModel.Brand = "Brand2";
            carModel.Model = "Model2";
            carModel.Weight = 1200;
            carModel.RegistrationPlate = "regPlate";
            carModel.Id = car.Id;
            await carService.ChangeCarDetailsAsync(carModel, "user1");

            Assert.Equal(carModel.Brand, car.Brand);
            Assert.Equal(carModel.Model, car.Model);
            Assert.Equal(carModel.Weight, car.Weight);
            Assert.Equal(carModel.RegistrationPlate, car.RegistrationPlate);
        }

        [Fact]
        public async Task ChangeCarDetailsAsyncShouldThrowsWrongCarOwnerException()
        {
            var carService = new CarService(this.carRepository.Object, this.extraRepository.Object, this.carExtraRepository.Object, this.mapper);
            var car = new Car();

            this.carRepository.Setup(x => x.AddAsync(It.IsAny<Car>()))
                .Callback((Car c) => car = c);

            var carModel = await this.AddCarAsync(carService);

            var cars = new List<Car>() { car };
            this.carRepository.Setup(x => x.All())
                .Returns(cars.AsQueryable());

            var ex = await Assert.ThrowsAsync<WrongCarOwnerException>(() => carService.ChangeCarDetailsAsync(carModel, "user4"));
            Assert.Equal("You are not the car owner!", ex.Message);
        }

        [Fact]
        public async Task CheckUserHaveACarShouldThrowInvalidCarException()
        {
            var carService = new CarService(this.carRepository.Object, this.extraRepository.Object, this.carExtraRepository.Object, this.mapper);
            var car = new Car();

            this.carRepository.Setup(x => x.AddAsync(It.IsAny<Car>()))
                .Callback((Car c) => car = c);

            await this.AddCarAsync(carService);

            var cars = new List<Car>() { car };
            this.carRepository.Setup(x => x.All())
                .Returns(cars.AsQueryable());
            this.carRepository.Setup(x => x.AllAsNoTracking())
                .Returns(cars.AsQueryable());

            var ex = Assert.Throws<InvalidCarException>(() => carService.CheckUserHaveACar("randomUser", car.Id));
            Assert.Equal("Pick a valid car.", ex.Message);
        }

        [Fact]
        public async Task DeleteCarAsyncShouldDeleteTheCar()
        {
            var carService = new CarService(this.carRepository.Object, this.extraRepository.Object, this.carExtraRepository.Object, this.mapper);
            var car = new Car();

            await this.AddCarAsync(carService);

            var cars = new List<Car>() { car };
            this.carRepository.Setup(x => x.All())
                .Returns(cars.AsQueryable());

            this.carRepository.Setup(x => x.AddAsync(It.IsAny<Car>()))
                .Callback((Car c) => car = c);
            this.carRepository.Setup(x => x.Delete(It.IsAny<Car>()))
                .Callback((Car c) => cars.Remove(c));

            await carService.DeleteCarAsync(car.Id, car.UserId);

            Assert.Empty(cars);
        }

        private async Task<DetailedCarViewModel> AddCarAsync(ICarService carService)
        {
            var carModel = new DetailedCarViewModel()
            {
                Brand = "Brand",
                Model = "Model",
                Color = "Red",
                FuelType = FuelType.Diesel,
                Weight = 1000,
                NumberOfSeats = 4,
                RegistrationPlate = "PK4200PP",
                TransmissionType = TransmissionType.Automated,
                YearMade = 2005,
                VehicleIdentificationNumber = "1234567890abcdefg",
            };

            await carService.AddCarAsync("user1", carModel);

            return carModel;
        }

        private IEnumerable<Car> GetCars()
        {
            var cars = new List<Car>();

            for (int i = 0; i < this.carsCount; i++)
            {
                cars.Add(new Car()
                {
                    UserId = $"user{i}",
                    Brand = "Brand",
                    Id = $"car{i + 1}",
                    Model = "Model",
                    RegistrationPlate = "regPlate",
                    CreatedOn = DateTime.Now,
                });
            }

            return cars;
        }
    }
}
