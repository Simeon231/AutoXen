namespace AutoXen.Services.Data.Administration
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using AutoXen.Common;
    using AutoXen.Data.Models;
    using AutoXen.Web.ViewModels.Administration.Requests;

    public class RequestsAdminService : IRequestsAdminService
    {
        private readonly IWorkshopService workshopService;
        private readonly ICarWashService carWashService;
        private readonly IInsuranceService insuranceService;
        private readonly IMapper mapper;

        public RequestsAdminService(
            IWorkshopService workshopService,
            ICarWashService carWashService,
            IInsuranceService insuranceService,
            IMapper mapper)
        {
            this.workshopService = workshopService;
            this.carWashService = carWashService;
            this.insuranceService = insuranceService;
            this.mapper = mapper;
        }

        public async Task AcceptRequestAsync(AcceptViewModel model)
        {
            switch (model.RequestName)
            {
                case nameof(GlobalConstants.Workshop):
                    await this.workshopService.AcceptAsync(model);
                    break;
                case nameof(GlobalConstants.CarWash):
                    await this.carWashService.AcceptAsync(model);
                    break;
            }
        }

        public RequestsViewModel GetAllRequests(AdminFilterViewModel model, string userId, int itemsPerPage = 10)
        {
            var workshops = model.Workshops ? this.GetWorkshopRequests(model.Accepted, model.AcceptedByMe, model.Done, userId) : new List<RequestViewModel>();
            var carwashes = model.CarWashes ? this.GetCarWashRequests(model.Accepted, model.AcceptedByMe, model.Done, userId) : new List<RequestViewModel>();
            var insurances = model.Insurances ? this.GetInsuranceRequests(model.Accepted, model.AcceptedByMe, model.Done, userId) : new List<RequestViewModel>();

            var requests = this.mapper.Map<RequestsViewModel>(model);
            requests.ItemsPerPage = itemsPerPage;
            requests.Routes = this.GetRequestRoutes(model);

            requests.Requests.AddRange(workshops);
            requests.Requests.AddRange(carwashes);
            requests.Requests.AddRange(insurances);
            requests.RequestsCount = requests.Requests.Count;

            var maximumPage = ((requests.RequestsCount - 1) / itemsPerPage) + 1;
            requests.PageNumber = maximumPage >= model.PageNumber ? model.PageNumber : maximumPage;
            requests.Requests = requests.Requests.OrderByDescending(x => x.CreatedOn).Skip((requests.PageNumber - 1) * itemsPerPage).Take(itemsPerPage).ToList();

            return requests;
        }

        private IEnumerable<RequestViewModel> GetWorkshopRequests(bool accepted, bool acceptedByMe, bool done, string userId)
        {
            var requests = this.workshopService
                .GetAllRequests();

            return this.FilterRequests(requests, accepted, acceptedByMe, done, userId);
        }

        private IEnumerable<RequestViewModel> GetCarWashRequests(bool accepted, bool acceptedByMe, bool done, string userId)
        {
            var requests = this.carWashService
                .GetAllRequests();

            return this.FilterRequests(requests, accepted, acceptedByMe, done, userId);
        }

        private IEnumerable<RequestViewModel> GetInsuranceRequests(bool accepted, bool acceptedByMe, bool done, string userId)
        {
            var requests = this.insuranceService
                .GetAllRequests();

            return this.FilterRequests(requests, accepted, acceptedByMe, done, userId);
        }

        private IEnumerable<RequestViewModel> FilterRequests(IQueryable<IRequest> requests, bool accepted, bool acceptedByMe, bool done, string userId)
        {
            return requests
                .Where(x =>
                    (!string.IsNullOrEmpty(x.AcceptedById) == accepted)
                    && (x.AcceptedById == userId == acceptedByMe)
                    && (x.FinishedOn != null == done))
                .Select(x => this.mapper.Map<RequestViewModel>(x))
                .ToList();
        }

        private IDictionary<string, string> GetRequestRoutes(AdminFilterViewModel filter)
        {
            return new Dictionary<string, string>
            {
                [nameof(filter.Accepted)] = filter.Accepted.ToString(),
                [nameof(filter.AcceptedByMe)] = filter.AcceptedByMe.ToString(),
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
