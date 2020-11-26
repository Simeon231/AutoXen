namespace AutoXen.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AutoXen.Services.Data;
    using AutoXen.Web.ViewModels;
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
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = this.workshopService.GetWorkshopServices(userId);

            ////var complex = new ComplexViewModel<WorkshopViewModel, WorkshopGetViewModel>
            ////{
            ////    View = model,
            ////    Input = new WorkshopViewModel(),
            ////};

            return this.View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Index(WorkshopRequestViewModel input)
        {
            await this.workshopService.AddWorkshopRequestAsync(input);

            return this.RedirectToAction(nameof(RequestsController.Index));
        }
    }
}
