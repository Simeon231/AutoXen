namespace AutoXen.Web.Areas.Administration.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AutoXen.Services.Data;
    using AutoXen.Web.ViewModels.Administration.Workshop;
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
            var model = this.workshopService.GetWorkshopRequestDetails(userId, id, true);

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Details(WorkshopAdminViewModel input)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!this.ModelState.IsValid)
            {
                var model = this.workshopService.GetWorkshopRequestDetails(userId, input.Id, true);
                if (input.WorkshopId != null)
                {
                    var workshopId = (int)input.WorkshopId;
                    model.Workshop = new WorkshopViewModel()
                    {
                        Id = workshopId,
                    };

                    model.WorkshopServices = this.workshopService.GetWorkshopServicesIdsByRequestId(input.Id);
                }

                return this.View(model);
            }

            await this.workshopService.SubmitRequestAsync(input);

            return this.Redirect("/Administration/Requests");
        }
    }
}
