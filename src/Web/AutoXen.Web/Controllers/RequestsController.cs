namespace AutoXen.Web.Controllers
{
    using System.Security.Claims;

    using AutoXen.Services.Data.Requests;
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
        public IActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = this.requestsService.GetAll(userId);
            return this.View(model);
        }
    }
}
