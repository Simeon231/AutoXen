namespace AutoXen.Web.Areas.Administration.Controllers
{
    using AutoXen.Services.Data.Administration;
    using AutoXen.Web.ViewModels.Administration.Dashboard;
    using Microsoft.AspNetCore.Mvc;

    public class DashboardController : AdministrationController
    {
        private readonly IRequestsAdminService requestsAdminService;

        public DashboardController(IRequestsAdminService requestsAdminService)
        {
            this.requestsAdminService = requestsAdminService;
        }

        public IActionResult Index()
        {
            var model = this.requestsAdminService.GetDashboardInformation();

            return this.View(model);
        }
    }
}
