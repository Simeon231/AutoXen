namespace AutoXen.Services.Data.Requests
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using AutoXen.Data.Common.Repositories;
    using AutoXen.Data.Models.AnnualTechnicalInspection;
    using AutoXen.Data.Models.CarWash;
    using AutoXen.Data.Models.Insurance;
    using AutoXen.Data.Models.RoadsideAssistance;
    using AutoXen.Data.Models.Workshop;
    using AutoXen.Services.Data;
    using AutoXen.Web.ViewModels.Requests;

    public class RequestsService : IRequestsService
    {
        private readonly string carWashName = "Car wash";
        private readonly IDeletableEntityRepository<CarWashRequest> carWashRequestRepository;
        private readonly IDeletableEntityRepository<WorkshopRequest> workshopRequestRepository;
        private readonly IDeletableEntityRepository<AnnualTechnicalInspectionRequest> annualTechnicalInspectionRequestRepository;
        private readonly IDeletableEntityRepository<InsurersRequest> insurersRequestRepository;
        private readonly IDeletableEntityRepository<RoadsideAssistanceRequest> roadsideAssistanceRequestRepository;
        private readonly ICarWashService carWashService;
        private readonly IWorkshopService workshopService;
        private readonly IMapper mapper;

        public RequestsService(
            IDeletableEntityRepository<CarWashRequest> carWashRequestRepository,
            IDeletableEntityRepository<WorkshopRequest> workshopRequestRepository,
            IDeletableEntityRepository<AnnualTechnicalInspectionRequest> annualTechnicalInspectionRequestRepository,
            IDeletableEntityRepository<InsurersRequest> insurersRequestRepository,
            IDeletableEntityRepository<RoadsideAssistanceRequest> roadsideAssistanceRequestRepository,
            ICarWashService carWashService,
            IWorkshopService workshopService,
            IMapper mapper)
        {
            this.carWashRequestRepository = carWashRequestRepository;
            this.workshopRequestRepository = workshopRequestRepository;
            this.annualTechnicalInspectionRequestRepository = annualTechnicalInspectionRequestRepository;
            this.insurersRequestRepository = insurersRequestRepository;
            this.roadsideAssistanceRequestRepository = roadsideAssistanceRequestRepository;
            this.carWashService = carWashService;
            this.workshopService = workshopService;
            this.mapper = mapper;
        }

        public IEnumerable<RequestViewModel> GetAll(string userId)
        {
            var requests = new List<RequestViewModel>();

            requests.AddRange(this.carWashService.GetAllRequests(userId).Select(x => this.mapper.Map<RequestViewModel>(x)));
            requests.AddRange(this.workshopService.GetWorkshopRequests(userId).Select(x => this.mapper.Map<RequestViewModel>(x)));

            requests.OrderByDescending(x => x.CreatedOn);

            return requests.OrderByDescending(x => x.CreatedOn);
        }
    }
}
