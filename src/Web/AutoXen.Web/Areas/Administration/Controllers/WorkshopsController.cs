namespace AutoXen.Web.Areas.Administration.Controllers
{
    using System.Security.Claims;

    using AutoXen.Services.Data;
    using AutoXen.Web.ViewModels.Workshop;
    using Microsoft.AspNetCore.Mvc;

    public class WorkshopsController : AdministrationController
    {
        private readonly IWorkshopService workshopService;

        public WorkshopsController(
            IWorkshopService workshopService)
        {
            this.workshopService = workshopService;
        }

        public IActionResult Details(string id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = this.workshopService.GetWorkshopDetails(userId, id, true);

            return this.View(model);
        }

        [HttpPost]
        public IActionResult Details(WorkshopRequestDetailsViewModel input)
        {
            return this.Redirect("Administration/Requests");
        }
    }
}
