namespace AutoXen.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AutoXen.Services.Data;
    using AutoXen.Web.ViewModels.Workshop;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class WorkshopServicesController : ControllerBase
    {
        private readonly IWorkshopService workshopService;

        public WorkshopServicesController(IWorkshopService workshopService)
        {
            this.workshopService = workshopService;
        }

        [HttpGet]
        public IEnumerable<ServiceResponseModel> Get()
        {
            return this.workshopService.GetAllServices();
        }

        [HttpGet("{id}")]
        public IEnumerable<ServiceWithPriceResponseModel> Get(int id)
        {
            return this.workshopService.GetServicesByWorkshopId(id);
        }
    }
}
