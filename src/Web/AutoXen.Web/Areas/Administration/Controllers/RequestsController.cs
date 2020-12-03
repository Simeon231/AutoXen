namespace AutoXen.Web.Areas.Administration.Controllers
{
    using AutoXen.Services.Data.Administration;
    using Microsoft.AspNetCore.Mvc;

    public class RequestsController : AdministrationController
    {
        private readonly IRequestsService requestsService;

        public RequestsController(IRequestsService requestsService)
        {
            this.requestsService = requestsService;
        }

        public IActionResult Index()
        {
            var model = this.requestsService.GetAllRequests();

            return this.View(model);
        }

        public IActionResult AcceptRequest(string requestName, string id)
        {
            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
