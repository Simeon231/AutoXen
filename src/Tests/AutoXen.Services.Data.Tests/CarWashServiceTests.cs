namespace AutoXen.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using AutoXen.Common;
    using AutoXen.Data.Common.Repositories;
    using AutoXen.Data.Models.Car;
    using AutoXen.Data.Models.CarWash;
    using AutoXen.Web.Infrastructure.Profiles;
    using AutoXen.Web.ViewModels.Administration.CarWash;
    using AutoXen.Web.ViewModels.Administration.Common;
    using AutoXen.Web.ViewModels.Administration.Requests;
    using AutoXen.Web.ViewModels.CarWash;
    using AutoXen.Web.ViewModels.Common;
    using Moq;
    using Xunit;

    public class CarWashServiceTests
    {
        private readonly Mock<IDeletableEntityRepository<CarWashRequest>> requestRepository;
        private readonly Mock<IRepository<CarWash>> carWashRepository;
        private readonly Mock<IMessageService> messageService;
        private readonly Mock<ICarService> carService;
        private readonly IMapper mapper;
        private readonly int carWashesCount = 3;

        public CarWashServiceTests()
        {
            this.requestRepository = new Mock<IDeletableEntityRepository<CarWashRequest>>();
            this.carWashRepository = new Mock<IRepository<CarWash>>();
            this.messageService = new Mock<IMessageService>();
            this.carService = new Mock<ICarService>();
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CarWashProfile());
                cfg.AddProfile(new CarProfile());
                cfg.AddProfile(new AutoXen.Web.Infrastructure.Profiles.Administration.RequestsProfile());
            });
            this.mapper = mockMapper.CreateMapper();
        }

        [Fact]
        public async Task CarWashRequestShouldBeAddedCorrectly()
        {
            var request = new CarWashRequestViewModel()
            {
                CarId = "car1",
                CarWashId = 1,
                AdminChooseCarWash = true,
                Message = "Message",
                PickUpFastAsPossible = true,
                PickUpTime = DateTime.Now,
                PickUpLocation = "Sofia",
            };
            var user = "user1";

            var requests = new List<CarWashRequest>();

            this.requestRepository.Setup(x => x.AddAsync(It.IsAny<CarWashRequest>()))
                .Callback((CarWashRequest request) => requests.Add(request));

            MessageViewModel message = new MessageViewModel();

            this.messageService.Setup(x => x.AddMessageAsync(It.IsAny<MessageViewModel>()))
                .Callback((MessageViewModel model) => message = model);

            var service = new CarWashService(this.requestRepository.Object, this.carWashRepository.Object, this.carService.Object, this.messageService.Object, this.mapper);
            await service.AddCarWashRequestAsync(request, user);

            Assert.Single(requests);

            if (requests.Count == 1)
            {
                Assert.Null(requests[0].PickUpTime);
                Assert.Null(requests[0].CarWashId);
                Assert.Equal(user, requests[0].UserId);
                Assert.Equal(request.AdminChooseCarWash, requests[0].AdminChooseCarWash);
                Assert.Equal(request.PickUpLocation, requests[0].PickUpLocation);
                Assert.Equal(request.PickUpFastAsPossible, requests[0].PickUpFastAsPossible);
                Assert.Equal(request.CarId, requests[0].CarId);
                Assert.Equal(request.Message, message.Text);
            }
        }

        [Fact]
        public async Task GetCarWashRequestShouldReturnACarSuccessfully()
        {
            var request = new CarWashRequestViewModel()
            {
                CarId = "car1",
                CarWashId = 1,
                AdminChooseCarWash = false,
                Message = "Message",
                PickUpFastAsPossible = false,
                PickUpTime = DateTime.Now,
                PickUpLocation = "Sofia",
            };
            var user = "user1";
            var requests = new List<CarWashRequest>();

            this.requestRepository.Setup(x => x.AllWithDeleted())
                .Returns(requests.AsQueryable());

            var id = "1";
            var car = new Car()
            {
                Id = "car1",
                Brand = "Brand",
            };

            this.requestRepository.Setup(x => x.AddAsync(It.IsAny<CarWashRequest>()))
                .Callback((CarWashRequest request) =>
                {
                    request.Id = id;
                    request.Car = car;
                    requests.Add(request);
                });

            MessageViewModel message = new MessageViewModel();

            this.messageService.Setup(x => x.AddMessageAsync(It.IsAny<MessageViewModel>()))
                .Callback((MessageViewModel model) => message = model);

            var service = new CarWashService(this.requestRepository.Object, this.carWashRepository.Object, this.carService.Object, this.messageService.Object, this.mapper);
            await service.AddCarWashRequestAsync(request, user);
            var requestFromService = service.GetCarWashRequest(user, id);

            Assert.Equal(request.CarId, requestFromService.Car.Id);
            Assert.Equal(request.CarWashId, requestFromService.CarWashId);
            Assert.Equal(request.PickUpLocation, requestFromService.PickUpLocation);
            Assert.Equal(request.PickUpTime, requestFromService.PickUpTime);
            Assert.Equal(request.PickUpFastAsPossible, requestFromService.PickUpFastAsPossible);
            Assert.Equal(user, requestFromService.UserId);
        }

        [Fact]
        public async Task AcceptAsyncShouldAcceptRequestSuccessfully()
        {
            var service = new CarWashService(this.requestRepository.Object, this.carWashRepository.Object, this.carService.Object, this.messageService.Object, this.mapper);
            var requests = this.GetCarWashRequests();

            this.requestRepository.Setup(x => x.All())
                .Returns(requests.AsQueryable());

            var id = "request2";
            var acceptModel = new AcceptViewModel()
            {
                Id = id,
                RequestName = GlobalConstants.Workshop,
                AdminId = "admin1",
            };

            await service.AcceptAsync(acceptModel);

            var request = requests.FirstOrDefault(x => x.Id == id);

            Assert.Equal(acceptModel.AdminId, request.AcceptedById);
        }

        [Fact]
        public void GetAllRequestsByIdShoudReturnAllRequestsByIdSuccessfully()
        {
            var service = new CarWashService(this.requestRepository.Object, this.carWashRepository.Object, this.carService.Object, this.messageService.Object, this.mapper);
            var requests = this.GetCarWashRequests();
            var user = "user1";
            requests.Add(new CarWashRequest()
            {
                Id = "request4",
                UserId = user,
            });

            this.requestRepository.Setup(x => x.AllWithDeleted())
                .Returns(requests.AsQueryable());

            var usersRequests = service.GetAllRequestsByUserId(user);

            Assert.Equal(2, usersRequests.Count());
        }

        [Fact]
        public void GetAllRequestsShouldReturnAllRequestsSuccessfully()
        {
            var service = new CarWashService(this.requestRepository.Object, this.carWashRepository.Object, this.carService.Object, this.messageService.Object, this.mapper);
            var requests = this.GetCarWashRequests();

            this.requestRepository.Setup(x => x.AllAsNoTracking())
                .Returns(requests.AsQueryable());

            var allRequests = service.GetAllRequests();

            Assert.Equal(3, allRequests.Count());
        }

        [Fact]
        public async Task SubmitRequestAsyncShouldSubmitTheRequestSuccessfully()
        {
            var service = new CarWashService(this.requestRepository.Object, this.carWashRepository.Object, this.carService.Object, this.messageService.Object, this.mapper);
            var requests = this.GetCarWashRequests();

            this.requestRepository.Setup(x => x.All())
                .Returns(requests.AsQueryable());

            var id = "request1";
            var adminModel = new AdminCarWashDetailsViewModel()
            {
                Id = id,
                AdminChooseCarWash = false,
                CarWashId = 1,
                PickUpFastAsPossible = true,
                PickUpLocation = "Sofia",
                RequestInformation = new AdminRequestInformationViewModel()
                {
                    FinishedOn = DateTime.Now,
                    PickedUp = true,
                    ReturnedCar = true,
                    ServiceFinished = true,
                    UserId = "user1",
                },
            };

            await service.SubmitRequestAsync(adminModel);

            var request = requests.FirstOrDefault(x => x.Id == id);

            Assert.Equal(adminModel.AdminChooseCarWash, request.AdminChooseCarWash);
            Assert.Equal(adminModel.CarWashId, request.CarWashId);
            Assert.Equal(adminModel.PickUpFastAsPossible, request.PickUpFastAsPossible);
            Assert.Equal(adminModel.PickUpLocation, request.PickUpLocation);
            Assert.Equal(adminModel.RequestInformation.PickedUp, request.PickedUp);
            Assert.Equal(adminModel.RequestInformation.ReturnedCar, request.ReturnedCar);
            Assert.Equal(adminModel.RequestInformation.ServiceFinished, request.ServiceFinished);
            Assert.Equal(adminModel.RequestInformation.UserId, request.UserId);
        }

        [Fact]
        public void GetAllCarWashesShouldReturnAllCarWashes()
        {
            var service = new CarWashService(this.requestRepository.Object, this.carWashRepository.Object, this.carService.Object, this.messageService.Object, this.mapper);
            var carWashes = this.GetCarWashes();

            this.carWashRepository.Setup(x => x.AllAsNoTracking())
                .Returns(carWashes.AsQueryable());

            var carWashesModel = service.GetAllCarWashes().ToList();

            Assert.Equal(this.carWashesCount, carWashesModel.Count());

            for (int i = 1; i <= this.carWashesCount; i++)
            {
                Assert.Equal(i, carWashesModel[i - 1].Id);
                Assert.Equal($"carWash{i}", carWashes[i - 1].Name);
            }
        }

        private List<CarWashRequest> GetCarWashRequests()
        {
            var requests = new List<CarWashRequest>();

            var carWashRequestsCount = 3;
            for (int i = 1; i <= carWashRequestsCount; i++)
            {
                var request = new CarWashRequest()
                {
                    Id = $"request{i}",
                    CarId = $"car{i}",
                    CarWashId = i,
                    UserId = $"user{i}",
                };

                requests.Add(request);
            }

            return requests;
        }

        private List<CarWash> GetCarWashes()
        {
            var carWashes = new List<CarWash>();

            for (int i = 1; i <= this.carWashesCount; i++)
            {
                var carWash = new CarWash()
                {
                    Id = i,
                    Name = $"carWash{i}",
                    Price = 10.5 * i,
                };

                carWashes.Add(carWash);
            }

            return carWashes;
        }
    }
}
