namespace AutoXen.Services.Data.Administration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using AutoXen.Data.Common.Repositories;
    using AutoXen.Data.Models.CarWash;
    using AutoXen.Data.Models.Workshop;
    using AutoXen.Web.ViewModels.Administration.Requests;

    public class RequestsService : IRequestsService
    {
        private readonly IDeletableEntityRepository<WorkshopRequest> workshopRequestService;
        private readonly IDeletableEntityRepository<CarWashRequest> carWashRequestService;
        private readonly IWorkshopService workshopService;
        private readonly ICarWashService carWashService;
        private readonly IMapper mapper;

        public RequestsService(
            IDeletableEntityRepository<WorkshopRequest> workshopRequestService,
            IDeletableEntityRepository<CarWashRequest> carWashRequestService,
            IWorkshopService workshopService,
            ICarWashService carWashService,
            IMapper mapper)
        {
            this.workshopRequestService = workshopRequestService;
            this.carWashRequestService = carWashRequestService;
            this.workshopService = workshopService;
            this.carWashService = carWashService;
            this.mapper = mapper;
        }

        public IEnumerable<RequestViewModel> GetAllRequests()
        {
            var requests = new List<RequestViewModel>();

            requests.AddRange(this.workshopService.GetAllRequests().Select(x => this.mapper.Map<RequestViewModel>(x)));
            requests.AddRange(this.carWashService.GetAllRequests().Select(x => this.mapper.Map<RequestViewModel>(x)));

            return requests.OrderByDescending(x => x.CreatedOn);
        }
    }
}
