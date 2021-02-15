﻿namespace AutoXen.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using AutoXen.Data.Models.CarWash;
    using AutoXen.Data.Models.Workshop;
    using AutoXen.Web.Infrastructure.Profiles;
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

        [Fact]
        public void GetAllShouldReturnAllRequests()
        {
            var carWashRequests = this.GetCarWashRequests();
            this.carWashService.Setup(x => x.GetAllRequestsByUserId(string.Empty))
                .Returns(carWashRequests);

            var workshopRequests = this.GetWorkshopRequests();
            this.workshopService.Setup(x => x.GetWorkshopRequestsByUserId(string.Empty))
                .Returns(workshopRequests);

            var service = new RequestsService(this.carWashService.Object, this.workshopService.Object, this.mapper);
            var requests = service.GetAll(string.Empty).ToList();

            Assert.Equal(6, requests.Count());
            Assert.Equal("workshopRequest2", requests.First().Id);
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