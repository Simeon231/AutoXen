namespace AutoXen.Web.Areas.Administration.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

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
        public async Task<IActionResult> Details(AdminInsuranceRequestViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                var model = this.insuranceService.GetInsuranceRequestDetails(string.Empty, input.Id, true);

                return this.View(model);
            }

            await this.insuranceService.SubmitRequestAsync(input);

            return this.Redirect("/Administration/Requests");
        }
    }
}
