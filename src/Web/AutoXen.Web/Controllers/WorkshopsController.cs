namespace AutoXen.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AutoXen.Services.Data;
    using AutoXen.Services.Exceptions;
    using AutoXen.Web.ViewModels.Workshop;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class WorkshopsController : Controller
    {
        private readonly IWorkshopService workshopService;

        public WorkshopsController(IWorkshopService workshopService)
        {
            this.workshopService = workshopService;
        }

        [Authorize]
        public IActionResult Index()
        {
            return this.View(new WorkshopRequestViewModel());
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Index(WorkshopRequestViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            try
            {
                await this.workshopService.AddWorkshopRequestAsync(input, userId);
            }
            catch (InvalidCarException err)
            {
                this.ModelState.AddModelError("Invalid Car", err.Message);
                return this.View(input);
            }

            return this.Redirect("Requests/Index");
        }

        [Authorize]
        public IActionResult Details(string id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = this.workshopService.GetWorkshopRequestDetails(userId, id);

            return this.View(model);
        }
    }
}
