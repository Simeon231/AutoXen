namespace AutoXen.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AutoXen.Services.Data;
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
            await this.workshopService.AddWorkshopRequestAsync(input, userId);

            return this.Redirect("Requests/Index");
        }
    }
}
