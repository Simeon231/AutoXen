namespace AutoXen.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AutoXen.Common;
    using AutoXen.Services.Data;
    using AutoXen.Services.Exceptions;
    using AutoXen.Web.ViewModels.CarWash;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class CarWashesController : Controller
    {
        private readonly ICarWashService carWashService;

        public CarWashesController(ICarWashService carWashService)
        {
            this.carWashService = carWashService;
        }

        [Authorize]
        public ActionResult Index()
        {
            return this.View(new CarWashRequestViewModel());
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Index(CarWashRequestViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var isAdmin = this.User.IsInRole(GlobalConstants.AdministratorRoleName);
            try
            {
                await this.carWashService.AddCarWashRequestAsync(model, userId, isAdmin);
            }
            catch (InvalidCarException err)
            {
                this.ModelState.AddModelError("InvalidCar", err.Message);
                return this.View(model);
            }

            return this.Redirect("/Requests/Index");
        }

        [Authorize]
        public ActionResult Details(string id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = this.carWashService.GetCarWashRequest(userId, id);

            return this.View(model);
        }
    }
}
