namespace AutoXen.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using AutoXen.Web.ViewModels.Requests;

    public class RequestsService : IRequestsService
    {
        private readonly ICarWashService carWashService;
        private readonly IWorkshopService workshopService;
        private readonly IInsuranceService insuranceService;
        private readonly IMapper mapper;

        public RequestsService(
            ICarWashService carWashService,
            IWorkshopService workshopService,
            IInsuranceService insuranceService,
            IMapper mapper)
        {
            this.carWashService = carWashService;
            this.workshopService = workshopService;
            this.insuranceService = insuranceService;
            this.mapper = mapper;
        }

        public RequestsViewModel GetAll(UserFilterViewModel model, string userId, int itemsPerPage = 10)
        {
            var workshopRequests = model.Workshops ? this.GetUsersWorkshopRequests(userId, model.Done) : new List<RequestViewModel>();
            var carwashRequests = model.CarWashes ? this.GetUsersCarWashRequests(userId, model.Done) : new List<RequestViewModel>();
            var insuranceRequests = model.Insurances ? this.GetUsersInsuranceRequests(userId, model.Done) : new List<RequestViewModel>();

            var requests = this.mapper.Map<RequestsViewModel>(model);
            requests.Requests = new List<RequestViewModel>();

            requests.ItemsPerPage = itemsPerPage;
            requests.Routes = this.GetRequestRoutes(model);

            requests.Requests.AddRange(workshopRequests);
            requests.Requests.AddRange(carwashRequests);
            requests.Requests.AddRange(insuranceRequests);
            requests.RequestsCount = requests.Requests.Count;

            var maximumPage = ((requests.RequestsCount - 1) / itemsPerPage) + 1;
            requests.PageNumber = maximumPage >= model.PageNumber ? model.PageNumber : maximumPage;
            requests.Requests = requests.Requests.OrderByDescending(x => x.CreatedOn).Skip((requests.PageNumber - 1) * itemsPerPage).Take(itemsPerPage).ToList();

            return requests;
        }

        private IEnumerable<RequestViewModel> GetUsersWorkshopRequests(string userId, bool done)
        {
            return this.workshopService
                .GetAllRequestsByUserId(userId)
                .Where(x => (x.FinishedOn != null) == done)
                .Select(x => this.mapper.Map<RequestViewModel>(x))
                .ToList();
        }

        private IEnumerable<RequestViewModel> GetUsersCarWashRequests(string userId, bool done)
        {
            return this.carWashService
                .GetAllRequestsByUserId(userId)
                .Where(x => (x.FinishedOn != null) == done)
                .Select(x => this.mapper.Map<RequestViewModel>(x))
                .ToList();
        }

        private IEnumerable<RequestViewModel> GetUsersInsuranceRequests(string userId, bool done)
        {
            return this.insuranceService
                .GetAllRequestsByUserId(userId)
                .Where(x => (x.FinishedOn != null) == done)
                .Select(x => this.mapper.Map<RequestViewModel>(x))
                .ToList();
        }

        private IDictionary<string, string> GetRequestRoutes(UserFilterViewModel filter)
        {
            return new Dictionary<string, string>
            {
                [nameof(filter.RoadsideAssistance)] = filter.RoadsideAssistance.ToString(),
                [nameof(filter.Insurances)] = filter.Insurances.ToString(),
                [nameof(filter.AnnualTechnicalInspections)] = filter.AnnualTechnicalInspections.ToString(),
                [nameof(filter.CarWashes)] = filter.CarWashes.ToString(),
                [nameof(filter.Workshops)] = filter.Workshops.ToString(),
                [nameof(filter.Done)] = filter.Done.ToString(),
            };
        }
    }
}
