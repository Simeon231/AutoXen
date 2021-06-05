namespace AutoXen.Web.Areas.Administration.Controllers
{
    using AutoXen.Services.Data;
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
    }
}
