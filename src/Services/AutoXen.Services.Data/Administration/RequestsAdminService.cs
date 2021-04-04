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

        public RequestsViewModel GetAllRequests(FilterViewModel model, int itemsPerPage = 10)
        {
            // TODO needs refactoring
            var page = model.PageNumber;
            var workshops = model.Workshops ?
                this.workshopService.GetAllRequests().Select(x => this.mapper.Map<RequestViewModel>(x)).ToList() :
                new List<RequestViewModel>();
            var carwashes = model.CarWashes ?
                this.carWashService.GetAllRequests().Select(x => this.mapper.Map<RequestViewModel>(x)).ToList() :
                new List<RequestViewModel>();

            var requests = new RequestsViewModel()
            {
                ItemsPerPage = itemsPerPage,
                PageNumber = page,
                RequestsCount = workshops.Count + carwashes.Count,
                Insurances = model.Insurances,
                Accepted = model.Accepted,
                RoadsideAssistance = model.RoadsideAssistance,
                AcceptedByMe = model.AcceptedByMe,
                AnnualTechnicalInspections = model.AnnualTechnicalInspections,
                CarWashes = model.CarWashes,
                Workshops = model.Workshops,
            };

            requests.Routes = new Dictionary<string, string>
            {
                [nameof(model.Accepted)] = model.Accepted.ToString(),
                [nameof(model.AcceptedByMe)] = model.AcceptedByMe.ToString(),
                [nameof(model.RoadsideAssistance)] = model.RoadsideAssistance.ToString(),
                [nameof(model.Insurances)] = model.Insurances.ToString(),
                [nameof(model.AnnualTechnicalInspections)] = model.AnnualTechnicalInspections.ToString(),
                [nameof(model.CarWashes)] = model.CarWashes.ToString(),
                [nameof(model.Workshops)] = model.Workshops.ToString(),
            };

            requests.Requests.AddRange(workshops);
            requests.Requests.AddRange(carwashes);
            requests.Requests = requests.Requests.OrderByDescending(x => x.CreatedOn).Skip((page - 1) * itemsPerPage).Take(itemsPerPage).ToList();

            return requests;
        }
    }
}
