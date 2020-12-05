namespace AutoXen.Services.Data.Administration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoXen.Common;
    using AutoXen.Data.Common.Models;
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

        public async Task AcceptRequestAsync(string requestName, string requestId)
        {
            // TODO !!!
            switch (requestName)
            {
                case GlobalConstants.Workshop: await this.workshopService.AcceptAsync(string.Empty, requestId);
                    break;
            }
        }

        public RequestsViewModel GetAllRequests(int page, int itemsPerPage = 10)
        {
            var workshops = this.workshopService.GetAllRequests().Select(x => this.mapper.Map<RequestViewModel>(x)).ToList();
            var carwashes = this.carWashService.GetAllRequests().Select(x => this.mapper.Map<RequestViewModel>(x)).ToList();

            var requests = new RequestsViewModel()
            {
                ItemsPerPage = itemsPerPage,
                PageNumber = page,
                RequestsCount = workshops.Count() + carwashes.Count(),
            };

            requests.Requests.AddRange(workshops);
            requests.Requests.AddRange(carwashes);
            requests.Requests = requests.Requests.OrderByDescending(x => x.CreatedOn).Skip((page - 1) * itemsPerPage).Take(itemsPerPage).ToList();

            return requests;
        }
    }
}
