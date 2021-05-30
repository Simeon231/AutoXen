namespace AutoXen.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AutoXen.Services.Data;
    using AutoXen.Services.Exceptions;
    using AutoXen.Web.ViewModels.Cars;
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
            var cars = this.carService.GetAllCarsByUserId(userId);
            return this.View(cars);
        }

        [Authorize]
        public IActionResult Add()
        {
            return this.View("~/Views/Cars/Car.cshtml");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(DetailedCarViewModel car)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View("~/Views/Cars/Car.cshtml", car);
            }

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await this.carService.AddCarAsync(userId, car);

            return this.RedirectToAction(nameof(this.All));
        }

        [Authorize]
        public IActionResult Details(string id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            DetailedCarViewModel model;

            try
            {
                model = this.carService.GetCarDetails(id, userId);
            }
            catch (WrongCarOwnerException)
            {
                return this.Redirect("/Cars/All");
            }

            return this.View("~/Views/Cars/Car.cshtml", model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Details(DetailedCarViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View("~/Views/Cars/Car.cshtml", input);
            }

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                await this.carService.ChangeCarDetailsAsync(input, userId);
            }
            catch (WrongCarOwnerException)
            {
                return this.Redirect("/");
            }

            return this.RedirectToAction(nameof(this.All));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                await this.carService.DeleteCarAsync(id, userId);
            }
            catch (WrongCarOwnerException)
            {
                return this.Redirect("/");
            }

            return this.RedirectToAction(nameof(this.All));
        }
    }
}
