namespace AutoXen.Services.Data.Administration
{
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using AutoXen.Common;
    using AutoXen.Data.Common.Repositories;
    using AutoXen.Data.Models.CarWash;
    using AutoXen.Data.Models.Workshop;
    using AutoXen.Web.ViewModels.Administration.Requests;

    public class RequestsAdminService : IRequestsAdminService
    {
        private readonly IDeletableEntityRepository<WorkshopRequest> workshopRequestServiceRepository;
        private readonly IDeletableEntityRepository<CarWashRequest> carWashRequestServiceRepository;
        private readonly IWorkshopService workshopService;
        private readonly ICarWashService carWashService;
        private readonly IMapper mapper;

        public RequestsAdminService(
            IDeletableEntityRepository<WorkshopRequest> workshopRequestServiceRepository,
            IDeletableEntityRepository<CarWashRequest> carWashRequestServiceRepository,
            IWorkshopService workshopService,
            ICarWashService carWashService,
            IMapper mapper)
        {
            this.workshopRequestServiceRepository = workshopRequestServiceRepository;
            this.carWashRequestServiceRepository = carWashRequestServiceRepository;
            this.workshopService = workshopService;
            this.carWashService = carWashService;
            this.mapper = mapper;
        }

        public async Task AcceptRequestAsync(AcceptViewModel model)
        {
            switch (model.RequestName)
            {
                case GlobalConstants.Workshop:
                    await this.workshopService.AcceptAsync(model);
                    break;
                case GlobalConstants.CarWash:
                    await this.carWashService.AcceptAsync(model);
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
