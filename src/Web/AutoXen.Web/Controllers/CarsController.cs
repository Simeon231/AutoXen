namespace AutoXen.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AutoXen.Services.Data;
    using AutoXen.Web.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class CarsController : Controller
    {
        private readonly ICarService carService;

        public CarsController(ICarService carService)
        {
            this.carService = carService;
        }

        [Authorize]
        public IActionResult All()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cars = this.carService.AllCars(userId);
            return this.View(cars);
        }

        [Authorize]
        public IActionResult Add()
        {
            return this.View("~/Views/Cars/Car.cshtml");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(DetailedCarWithoutIdViewModel car)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await this.carService.AddCarAsync(userId, car);

            return this.RedirectToAction(nameof(this.All));
        }

        [Authorize]
        public IActionResult Details(string id)
        {
            var model = this.carService.GetCarDetails(id);
            return this.View("~/Views/Cars/Car.cshtml", model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Details(DetailedCarWithIdViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View("~/Views/Cars/Car.cshtml", input);
            }

            await this.carService.ChangeCarDetailsAsync(input);
            return this.RedirectToAction(nameof(this.All));
        }

        [Authorize]
        public async Task<IActionResult> Delete(string id)
        {
            await this.carService.Delete(id);

            return this.RedirectToAction(nameof(this.All));
        }
    }
}
