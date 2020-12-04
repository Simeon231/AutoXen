namespace AutoXen.Web.Areas.Administration.Controllers
{
    using AutoXen.Services.Data;
    using AutoXen.Services.Data.Administration;
    using AutoXen.Web.ViewModels.Administration.Requests;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;

    public class RequestsController : AdministrationController
    {
        private readonly IRequestsService requestsService;
        private readonly IWorkshopService workshopService;

        public RequestsController(
            IRequestsService requestsService,
            IWorkshopService workshopService)
        {
            this.requestsService = requestsService;
            this.workshopService = workshopService;
        }

        public IActionResult Index(int id)
        {
            if (id == 0)
            {
                id = 1;
            }

            var model = this.requestsService.GetAllRequests(id);

            return this.View(model);
        }

        public IActionResult AcceptRequest(string requestName, string id)
        {
            // TODO accept
            return this.RedirectToAction(nameof(this.Index));
        }

        public IActionResult WorkshopRequest(string requestId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = this.workshopService.GetWorkshopDetails(userId, requestId);

            return this.View();
        }
    }
}
