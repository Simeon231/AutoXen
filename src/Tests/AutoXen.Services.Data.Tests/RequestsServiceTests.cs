namespace AutoXen.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using AutoXen.Data.Models.CarWash;
    using AutoXen.Data.Models.Workshop;
    using AutoXen.Web.Infrastructure.Profiles;
    using AutoXen.Web.ViewModels.Requests;
    using Moq;
    using Xunit;

    public class RequestsServiceTests
    {
        private readonly Mock<ICarWashService> carWashService;
        private readonly Mock<IWorkshopService> workshopService;
        private readonly IMapper mapper;

        public RequestsServiceTests()
        {
            this.carWashService = new Mock<ICarWashService>();
            this.workshopService = new Mock<IWorkshopService>();
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new RequestsProfile());
            });
            this.mapper = mockMapper.CreateMapper();
        }

        // TODO FIX - doesn't work
        [Fact]
        public void GetAllShouldReturnAllCarWashRequests()
        {
            var carWashRequests = this.GetCarWashRequests();
            this.carWashService.Setup(x => x.GetAllRequestsByUserId(string.Empty))
                .Returns(carWashRequests.AsQueryable());

            var workshopRequests = this.GetWorkshopRequests();
            this.workshopService.Setup(x => x.GetAllRequestsByUserId(string.Empty))
                .Returns(workshopRequests.AsQueryable());

            var service = new RequestsService(this.carWashService.Object, this.workshopService.Object, null, this.mapper);
            var model = new UserFilterViewModel()
            {
                CarWashes = true,
                Workshops = false,
            };
            var requests = service.GetAll(model, string.Empty).Requests.ToList();

            Assert.Equal(3, requests.Count);
            Assert.Equal("carWashRequest0", requests.Last().Id);
        }

        private List<CarWashRequest> GetCarWashRequests()
        {
            var requests = new List<CarWashRequest>();

            for (int i = 0; i < 3; i++)
            {
                requests.Add(new CarWashRequest()
                {
                    Id = $"carWashRequest{i}",
                    CarId = $"car{i}",
                    PickUpLocation = $"PickUpLocation{i}",
                    ReturnedCar = true,
                    CreatedOn = DateTime.UtcNow,
                });
            }

            return requests;
        }

        private List<WorkshopRequest> GetWorkshopRequests()
        {
            var requests = new List<WorkshopRequest>();

            for (int i = 0; i < 3; i++)
            {
                requests.Add(new WorkshopRequest()
                {
                    Id = $"workshopRequest{i}",
                    CarId = $"car{i}",
                    PickUpLocation = $"PickUpLocation{i}",
                    ReturnedCar = false,
                    CreatedOn = DateTime.UtcNow,
                });
            }

            return requests;
        }
    }
}
