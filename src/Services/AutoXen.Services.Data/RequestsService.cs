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
        private readonly IMapper mapper;

        public RequestsService(
            ICarWashService carWashService,
            IWorkshopService workshopService,
            IMapper mapper)
        {
            this.carWashService = carWashService;
            this.workshopService = workshopService;
            this.mapper = mapper;
        }

        public RequestsViewModel GetAll(FilterViewModel model, string userId, int itemsPerPage = 10)
        {
            var workshopRequests = model.Workshops ? this.GetUsersWorkshopRequests(userId) : new List<RequestViewModel>();
            var carwashRequests = model.CarWashes ? this.GetUsersCarWashRequests(userId) : new List<RequestViewModel>();

            var requests = new RequestsViewModel()
            {
                Requests = new List<RequestViewModel>(),
            };

            requests.ItemsPerPage = itemsPerPage;
            requests.Routes = this.GetRequestRoutes(model);

            requests.Requests.AddRange(workshopRequests);
            requests.Requests.AddRange(carwashRequests);
            requests.RequestsCount = requests.Requests.Count;

            var maximumPage = ((requests.RequestsCount - 1) / itemsPerPage) + 1;
            requests.PageNumber = maximumPage >= model.PageNumber ? model.PageNumber : maximumPage;
            requests.Requests = requests.Requests.OrderByDescending(x => x.CreatedOn).Skip((requests.PageNumber - 1) * itemsPerPage).Take(itemsPerPage).ToList();

            return requests;
        }

        private IEnumerable<RequestViewModel> GetUsersWorkshopRequests(string userId)
        {
            return this.workshopService
                .GetAllRequestsByUserId(userId)
                .Select(x => this.mapper.Map<RequestViewModel>(x))
                .AsEnumerable();
        }

        private IEnumerable<RequestViewModel> GetUsersCarWashRequests(string userId)
        {
            return this.carWashService
                .GetAllRequestsByUserId(userId)
                .Select(x => this.mapper.Map<RequestViewModel>(x))
                .AsEnumerable();
        }

        private IDictionary<string, string> GetRequestRoutes(FilterViewModel filter)
        {
            return new Dictionary<string, string>
            {
                [nameof(filter.RoadsideAssistance)] = filter.RoadsideAssistance.ToString(),
                [nameof(filter.Insurances)] = filter.Insurances.ToString(),
                [nameof(filter.AnnualTechnicalInspections)] = filter.AnnualTechnicalInspections.ToString(),
                [nameof(filter.CarWashes)] = filter.CarWashes.ToString(),
                [nameof(filter.Workshops)] = filter.Workshops.ToString(),
            };
        }
    }
}
