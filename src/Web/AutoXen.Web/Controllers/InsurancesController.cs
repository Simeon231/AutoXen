namespace AutoXen.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AutoXen.Services.Data;
    using AutoXen.Services.Exceptions;
    using AutoXen.Web.ViewModels.Insurance;
    using Microsoft.AspNetCore.Mvc;

    public class InsurancesController : Controller
    {
        private readonly IInsuranceService insuranceService;

        public InsurancesController(IInsuranceService insuranceService)
        {
            this.insuranceService = insuranceService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(InsuranceRequestViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
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
            return this.View();
        }
    }
}
