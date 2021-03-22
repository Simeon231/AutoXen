namespace AutoXen.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using AutoXen.Common;
    using AutoXen.Data.Common.Repositories;
    using AutoXen.Data.Models.Workshop;
    using AutoXen.Web.Infrastructure.Profiles;
    using AutoXen.Web.ViewModels.Administration.Common;
    using AutoXen.Web.ViewModels.Administration.Requests;
    using AutoXen.Web.ViewModels.Administration.Workshop;
    using AutoXen.Web.ViewModels.Common;
    using AutoXen.Web.ViewModels.Workshop;
    using Moq;
    using Xunit;

    public class WorkshopServiceTests
    {
        private readonly Mock<IDeletableEntityRepository<WorkshopRequest>> workshopRequestRepository;
        private readonly Mock<IRepository<WService>> serviceRepository;
        private readonly Mock<IRepository<Workshop>> workshopRepository;
        private readonly Mock<IRepository<AutoXen.Data.Models.Workshop.WorkshopService>> workshopServiceRepository;
        private readonly Mock<IRepository<WorkshopRequestWorkshopService>> workshopRequestWorkshopServiceRepository;
        private readonly Mock<IRepository<WorkshopRequestWService>> workshopRequestWServiceRepository;
        private readonly Mock<IMessageService> messageService;
        private readonly Mock<ICarService> carService;
        private readonly IMapper mapper;
        private readonly int repoCount = 5;
        private readonly List<WorkshopService> workshopServices = new List<WorkshopService>();

        public WorkshopServiceTests()
        {
            this.workshopRequestRepository = new Mock<IDeletableEntityRepository<WorkshopRequest>>();
            this.serviceRepository = new Mock<IRepository<WService>>();
            this.workshopRepository = new Mock<IRepository<Workshop>>();
            this.workshopServiceRepository = new Mock<IRepository<WorkshopService>>();
            this.workshopRequestWorkshopServiceRepository = new Mock<IRepository<WorkshopRequestWorkshopService>>();
            this.workshopRequestWServiceRepository = new Mock<IRepository<WorkshopRequestWService>>();
            this.messageService = new Mock<IMessageService>();
            this.carService = new Mock<ICarService>();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new WorkshopProfile());
                cfg.AddProfile(new CarProfile());
                cfg.AddProfile(new AutoXen.Web.Infrastructure.Profiles.Administration.RequestsProfile());
            });
            this.mapper = mockMapper.CreateMapper();

            this.AddWorkshops();
            this.AddWServices();
            this.AddWorkshopServices();
        }

        [Fact]
        public async Task AddWorkshopRequestAsyncShouldAddWServices()
        {
            var service = this.GetService();

            var requests = new List<WorkshopRequest>();
            this.workshopRequestRepository.Setup(x => x.AddAsync(It.IsAny<WorkshopRequest>()))
                .Callback((WorkshopRequest request) => requests.Add(request));

            var workshopRequestWServices = new List<WorkshopRequestWService>();
            this.workshopRequestWServiceRepository.Setup(x => x.AddAsync(It.IsAny<WorkshopRequestWService>()))
                .Callback((WorkshopRequestWService workshopRequestWService) => workshopRequestWServices.Add(workshopRequestWService));

            var model = this.GetRequestModel();
            model.Ids = RandomValues.RandomUniqueNumbers(this.repoCount, this.repoCount);

            await service.AddWorkshopRequestAsync(model, string.Empty);

            Assert.Single(requests);
            Assert.Equal(model.Ids.Count(), workshopRequestWServices.Count());
            Assert.Equal(model.Ids.First(), workshopRequestWServices[0].WServiceId);
            Assert.Equal(model.CarId, requests[0].CarId);
            Assert.Equal(model.AdminChooseWorkshop, requests[0].AdminChooseWorkshop);
            Assert.Equal(model.PickUpLocation, requests[0].PickUpLocation);
            Assert.Equal(model.PickUpTime, requests[0].PickUpTime);
        }

        [Fact]
        public async Task AddWorkshopRequestAsyncShouldAddSingleMessage()
        {
            var service = this.GetService();

            var requests = new List<WorkshopRequest>();
            this.workshopRequestRepository.Setup(x => x.AddAsync(It.IsAny<WorkshopRequest>()))
                .Callback((WorkshopRequest request) => requests.Add(request));

            var messages = new List<MessageViewModel>();
            this.messageService.Setup(x => x.AddMessageAsync(It.IsAny<MessageViewModel>()))
                .Callback((MessageViewModel message) => messages.Add(message));
            this.messageService.Setup(x => x.GetAllByRequestId(It.IsAny<string>()))
                .Returns(messages);

            var model = this.GetRequestModel();
            model.Message = "Message";

            await service.AddWorkshopRequestAsync(model, string.Empty);

            model.Message = null;
            await service.AddWorkshopRequestAsync(model, string.Empty);

            Assert.Single(this.messageService.Object.GetAllByRequestId(requests[0].Id));
            Assert.Equal(2, requests.Count());
        }

        [Fact]
        public async Task AddWorkshopRequestAsyncShouldAddWorkshopServices()
        {
            var service = this.GetService();

            var requests = new List<WorkshopRequest>();
            this.workshopRequestRepository.Setup(x => x.AddAsync(It.IsAny<WorkshopRequest>()))
                .Callback((WorkshopRequest request) => requests.Add(request));

            var workshopRequestWorkshopServices = new List<WorkshopRequestWorkshopService>();
            workshopRequestWorkshopServices.Add(
                new WorkshopRequestWorkshopService()
                {
                    WorkshopRequestId = "requestId",
                    Id = workshopRequestWorkshopServices.Count() + 1,
                    WorkshopServiceId = this.workshopServiceRepository.Object.AllAsNoTracking().FirstOrDefault().Id,
                });
            this.workshopRequestWorkshopServiceRepository.Setup(x => x.AllAsNoTracking())
                .Returns(workshopRequestWorkshopServices.AsQueryable());
            this.workshopRequestWorkshopServiceRepository.Setup(x => x.AddAsync(It.IsAny<WorkshopRequestWorkshopService>()))
                .Callback((WorkshopRequestWorkshopService workshopRequestWorkshopService) => workshopRequestWorkshopServices.Add(workshopRequestWorkshopService));

            var model = this.GetRequestModel();
            model.WorkshopId = 1;
            model.Ids = RandomValues.RandomUniqueNumbers(this.repoCount, this.repoCount);

            await service.AddWorkshopRequestAsync(model, string.Empty);

            model.WorkshopId = 2;
            await service.AddWorkshopRequestAsync(model, string.Empty);

            Assert.Equal(2, requests.Count());
            Assert.Equal(model.Ids.Count(), workshopRequestWorkshopServices.Count() / 2);
            Assert.Equal(model.Ids.First(), workshopRequestWorkshopServices[1].WorkshopServiceId);
            Assert.Equal(requests[0].Id, workshopRequestWorkshopServices[1].WorkshopRequestId);
        }

        [Fact]
        public async Task AcceptAsyncShouldChangeAcceptedByIdProperty()
        {
            var service = this.GetService();

            var requests = new List<WorkshopRequest>();
            requests.Add(new WorkshopRequest()
            {
                Id = "requestId",
                CarId = "carId",
            });
            requests.Add(new WorkshopRequest()
            {
                Id = "requestId2",
                CarId = "carId2",
            });

            this.workshopRequestRepository.Setup(x => x.All())
                .Returns(requests.AsQueryable());

            var model = new AcceptViewModel()
            {
                AdminId = "amdinId",
                RequestName = GlobalConstants.Workshop,
                Id = "requestId",
            };

            await service.AcceptAsync(model);

            Assert.Equal("amdinId", requests[0].AcceptedById);
            Assert.Null(requests[1].AcceptedById);
        }

        [Fact]
        public async Task SubmitRequestAsyncShouldChangePropertiesCorrectly()
        {
            var service = this.GetService();

            var requests = new List<WorkshopRequest>();
            requests.Add(new WorkshopRequest()
            {
                Id = "requestId",
                CarId = "carId",
                ReturnedCar = false,
                PickedUp = false,
                FinishedOn = null,
                OtherServices = "Other services",
                PickUpLocation = "Pick up location",
                PickUpTime = DateTime.Now,
                PickUpFastAsPossible = false,
                ModifiedOn = null,
                ServiceFinished = false,
            });

            this.workshopRequestRepository.Setup(x => x.All())
                .Returns(requests.AsQueryable());

            var model = new WorkshopAdminViewModel()
            {
                Id = "requestId",
                RequestInformation = new AdminRequestInformationViewModel()
                {
                    PickedUp = true,
                    FinishedOn = DateTime.UtcNow,
                    ServiceFinished = true,
                    ReturnedCar = true,
                },
                OtherServices = "changed Other services",
                PickUpLocation = "changed Pick up location",
                PickUpTime = DateTime.Now.AddHours(1),
                PickUpFastAsPossible = false,
                WorkshopId = 0, // TODO add WorkshopId
                ServiceIds = new List<int>(), // TODO add ServiceIds
            };

            await service.SubmitRequestAsync(model);

            Assert.Equal(model.Id, requests[0].Id);
            Assert.Equal(model.OtherServices, requests[0].OtherServices);
        }

        [Fact]
        public void GetAllWorkshopsShouldReturnAllWorkshops()
        {
            var service = this.GetService();

            var workshops = service.GetAllWorkshops();

            Assert.Equal(this.repoCount, workshops.Count());
        }

        [Fact]
        public void GetAllServicesShouldReturnAllServices()
        {
            var service = this.GetService();

            var services = service.GetAllServices();

            Assert.Equal(this.repoCount, services.Count());
        }

        [Fact]
        public void GetServicesByWorkshopIdShouldReturnAllServicesById()
        {
            var service = this.GetService();

            var workshopServices = service.GetServicesByWorkshopId(this.repoCount);

            Assert.Equal(this.workshopServices.Where(x => x.WorkshopId == this.repoCount).Count(), workshopServices.Count());

            workshopServices = service.GetServicesByWorkshopId(1);

            Assert.Equal(this.workshopServices.Where(x => x.WorkshopId == 1).Count(), workshopServices.Count());
        }

        [Fact]
        public void GetAllRequestsShouldReturnAllRequests()
        {
            var service = this.GetService();

            var requests = new List<WorkshopRequest>();
            for (int i = 1; i <= this.repoCount; i++)
            {
                requests.Add(new WorkshopRequest()
                {
                    CarId = $"car{i}",
                    Id = $"request{i}",
                    PickUpLocation = $"location{i}",
                    PickUpFastAsPossible = true,
                });
            }

            this.workshopRequestRepository.Setup(x => x.AllAsNoTracking())
                .Returns(requests.AsQueryable());

            var requestsFromService = service.GetAllRequests();

            Assert.Equal(this.repoCount, requestsFromService.Count());
        }

        private WorkshopRequestViewModel GetRequestModel()
        {
            return new WorkshopRequestViewModel()
            {
                AdminChooseWorkshop = true,
                CarId = "carId",
                PickUpLocation = "Sofia",
                PickUpTime = DateTime.Now.AddDays(1),
            };
        }

        private AutoXen.Services.Data.WorkshopService GetService()
        {
            return new AutoXen.Services.Data.WorkshopService(
                this.workshopRequestRepository.Object,
                this.serviceRepository.Object,
                this.workshopRepository.Object,
                this.workshopServiceRepository.Object,
                this.workshopRequestWorkshopServiceRepository.Object,
                this.workshopRequestWServiceRepository.Object,
                this.messageService.Object,
                this.carService.Object,
                this.mapper);
        }

        private void AddWorkshops()
        {
            var workshops = new List<Workshop>();

            for (int i = 1; i <= this.repoCount; i++)
            {
                workshops.Add(new Workshop()
                {
                    Address = $"address{i}",
                    CreatedOn = DateTime.Now,
                    Id = i,
                    Name = $"name{i}",
                });
            }

            this.workshopRepository.Setup(x => x.AllAsNoTracking())
                .Returns(workshops.AsQueryable());
        }

        private void AddWServices()
        {
            var wservices = new List<WService>();

            for (int i = 1; i <= this.repoCount; i++)
            {
                wservices.Add(new WService()
                {
                    CreatedOn = DateTime.Now,
                    Id = i,
                    Name = $"name{i}",
                });
            }

            this.serviceRepository.Setup(x => x.AllAsNoTracking())
                .Returns(wservices.AsQueryable());
        }

        private void AddWorkshopServices()
        {
            for (int i = 1; i <= this.repoCount; i++)
            {
                foreach (var num in RandomValues.RandomUniqueNumbers(this.repoCount, this.repoCount))
                {
                    this.workshopServices.Add(new WorkshopService()
                    {
                        Id = this.workshopServices.Count(),
                        Price = RandomValues.RandomPrice(),
                        ServiceId = num,
                        WorkshopId = i,
                    });
                }
            }

            this.workshopServiceRepository.Setup(x => x.AllAsNoTracking())
                .Returns(this.workshopServices.AsQueryable());
        }
    }
}
