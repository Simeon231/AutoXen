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

        public RequestsViewModel GetAll(FilterViewModel model, string userId)
        {
            var requests = new RequestsViewModel()
            {
                Requests = new List<RequestViewModel>(),
            };

            requests.Requests.AddRange(this.carWashService.GetAllRequestsByUserId(userId).Select(x => this.mapper.Map<RequestViewModel>(x)));
            requests.Requests.AddRange(this.workshopService.GetWorkshopRequestsByUserId(userId).Select(x => this.mapper.Map<RequestViewModel>(x)));

            requests.Requests = requests.Requests.OrderByDescending(x => x.CreatedOn).ToList();

            return requests;
        }
    }
}
