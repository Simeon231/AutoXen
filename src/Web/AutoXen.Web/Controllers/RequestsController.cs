namespace AutoXen.Web.Controllers
{
    using System.Security.Claims;

    using AutoXen.Services.Data;
    using AutoXen.Web.ViewModels.Requests;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class RequestsController : Controller
    {
        private readonly IRequestsService requestsService;

        public RequestsController(IRequestsService requestsService)
        {
            this.requestsService = requestsService;
        }

        [Authorize]
        public IActionResult Index(FilterViewModel input)
        {
            if (input.PageNumber <= 0)
            {
                // default values
                input.PageNumber = 1;
                input.Workshops = true;
                input.CarWashes = true;
                input.AnnualTechnicalInspections = true;
                input.RoadsideAssistance = true;
                input.Insurances = true;
            }

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = this.requestsService.GetAll(input, userId);
            return this.View(model);
        }
    }
}
