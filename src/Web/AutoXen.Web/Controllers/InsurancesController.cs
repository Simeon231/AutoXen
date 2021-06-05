namespace AutoXen.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AutoXen.Services.Data;
    using AutoXen.Services.Exceptions;
    using AutoXen.Web.ViewModels.Insurance;
    using Microsoft.AspNetCore.Mvc;

    public class InsurancesController : Controller
    {
        private readonly IInsuranceService insuranceService;
        private readonly ICarService carService;

        public InsurancesController(
            IInsuranceService insuranceService,
            ICarService carService)
        {
            this.insuranceService = insuranceService;
            this.carService = carService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(InsuranceRequestViewModel input)
        {
            var carErros = this.carService.ValidateCarForInsuranceRequest(input.CarId);
            if (!this.ModelState.IsValid || carErros.Any())
            {
                foreach (var carError in carErros)
                {
                    this.ModelState.AddModelError(Guid.NewGuid().ToString(), carError);
                }

                return this.View(input);
            }

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            try
            {
                await this.insuranceService.AddInsuranceRequestAsync(input, userId);
            }
            catch (InvalidCarException err)
            {
                this.ModelState.AddModelError("Invalid Car", err.Message);
                return this.View(input);
            }

            return this.Redirect("Requests/Index");
        }

        public IActionResult Details(string id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = this.insuranceService.GetInsuranceRequestDetails(userId, id);

            return this.View(model);
        }
    }
}
