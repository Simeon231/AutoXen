namespace AutoXen.Services.Data.Administration
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using AutoXen.Common;
    using AutoXen.Web.ViewModels.Administration.Requests;

    public class RequestsAdminService : IRequestsAdminService
    {
        private readonly IWorkshopService workshopService;
        private readonly ICarWashService carWashService;
        private readonly IMapper mapper;

        public RequestsAdminService(
            IWorkshopService workshopService,
            ICarWashService carWashService,
            IMapper mapper)
        {
            this.workshopService = workshopService;
            this.carWashService = carWashService;
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

        public RequestsViewModel GetAllRequests(FilterViewModel model, string userId, int itemsPerPage = 10)
        {
            var workshops = model.Workshops ? this.GetWorkshopRequests(model.Accepted, model.AcceptedByMe, userId) : new List<RequestViewModel>();
            var carwashes = model.CarWashes ? this.GetCarWashRequests(model.Accepted, model.AcceptedByMe, userId) : new List<RequestViewModel>();

            var requests = this.mapper.Map<RequestsViewModel>(model);
            var pageNumber = model.PageNumber;

            requests.ItemsPerPage = itemsPerPage;
            requests.PageNumber = pageNumber;
            requests.RequestsCount = workshops.Count() + carwashes.Count();
            requests.Routes = this.GetRequestRoutes(model);

            requests.Requests.AddRange(workshops);
            requests.Requests.AddRange(carwashes);
            requests.Requests = requests.Requests.OrderByDescending(x => x.CreatedOn).Skip((pageNumber - 1) * itemsPerPage).Take(itemsPerPage).ToList();

            return requests;
        }

        private IEnumerable<RequestViewModel> GetWorkshopRequests(bool accepted, bool acceptedByMe, string userId)
        {
            var requests = this.workshopService
                .GetAllRequests()
                .Where(x => !string.IsNullOrEmpty(x.AcceptedById) == accepted || (acceptedByMe && x.AcceptedById == userId))
                .Select(x => this.mapper.Map<RequestViewModel>(x))
                .AsEnumerable();

            return requests;
        }

        private IEnumerable<RequestViewModel> GetCarWashRequests(bool accepted, bool acceptedByMe, string userId)
        {
            var requests = this.carWashService
                .GetAllRequests()
                .Where(x => !string.IsNullOrEmpty(x.AcceptedById) == accepted || (acceptedByMe && x.AcceptedById == userId))
                .Select(x => this.mapper.Map<RequestViewModel>(x))
                .AsEnumerable();

            return requests;
        }

        private IDictionary<string, string> GetRequestRoutes(FilterViewModel filter)
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
            };
        }
    }
}
