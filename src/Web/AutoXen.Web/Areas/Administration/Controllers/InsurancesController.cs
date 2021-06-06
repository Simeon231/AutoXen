namespace AutoXen.Web.Areas.Administration.Controllers
{
    using AutoXen.Services.Data;
    using AutoXen.Web.ViewModels.Administration.Insurance;
    using Microsoft.AspNetCore.Mvc;

    public class InsurancesController : AdministrationController
    {
        private readonly IInsuranceService insuranceService;

        public InsurancesController(IInsuranceService insuranceService)
        {
            this.insuranceService = insuranceService;
        }

        public IActionResult Details(string id)
        {
            var request = this.insuranceService.GetInsuranceRequestDetails(string.Empty, id, true);

            return this.View(request);
        }

        [HttpPost]
        public IActionResult Details(AdminInsuranceRequestViewModel input)
        {
            return this.View();
        }
    }
}
