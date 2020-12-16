namespace AutoXen.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using AutoXen.Services.Data;
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

        public IEnumerable<RequestViewModel> GetAll(string userId)
        {
            var requests = new List<RequestViewModel>();

            requests.AddRange(this.carWashService.GetAllRequestsById(userId).Select(x => this.mapper.Map<RequestViewModel>(x)));
            requests.AddRange(this.workshopService.GetWorkshopRequestsByUserId(userId).Select(x => this.mapper.Map<RequestViewModel>(x)));

            return requests.OrderByDescending(x => x.CreatedOn);
        }
    }
}
