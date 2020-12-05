namespace AutoXen.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AutoXen.Services.Data;
    using AutoXen.Services.Data.Exceptions;
    using AutoXen.Web.ViewModels.CarWash;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class CarWashesController : Controller
    {
        private readonly ICarWashService carWashService;
        private readonly ICarService carService;

        public CarWashesController(
            ICarWashService carWashService,
            ICarService carService)
        {
            this.carWashService = carWashService;
            this.carService = carService;
        }

        [Authorize]
        public ActionResult Index()
        {
            ////var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            ////var carWash = new CarWashRequestViewModel() { Cars = this.carService.AllCars(userId) };

            return this.View(new CarWashRequestViewModel()); ////carWash);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Index(CarWashRequestViewModel model)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!this.ModelState.IsValid)
            {
                ////model.Cars = this.carService.AllCars(userId);
                return this.View(model);
            }

            try
            {
                await this.carWashService.AddCarWashRequestAsync(model, userId);
            }
            catch (InvalidCarException err)
            {
                ////model.Cars = this.carService.AllCars(userId);
                this.ModelState.AddModelError("InvalidCar", err.Message);
                return this.View(model); ////.Cars);
            }

            return this.Redirect("/Requests/Index");
        }

        [Authorize]
        public ActionResult Details(string id)
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Details()
        {
            return null;
        }
    }
}
