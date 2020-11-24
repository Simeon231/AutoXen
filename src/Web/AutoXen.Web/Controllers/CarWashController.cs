namespace AutoXen.Controllers
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AutoXen.Services;
    using AutoXen.Web.ViewModels;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class CarWashController : Controller
    {
        private readonly ICarWashService carWashService;
        private readonly ICarService carService;

        public CarWashController(
            ICarWashService carWashService,
            ICarService carService)
        {
            this.carWashService = carWashService;
            this.carService = carService;
        }

        public ActionResult Create()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var carWash = new CarWashRequestViewModel() { Cars = this.carService.AllCars(userId) };

            return this.View(carWash);
        }

        // TODO: [Authorize] [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Create(CarWashRequestViewModel model)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var carWash = new CarWashRequestViewModel() { Cars = this.carService.AllCars(userId) };

            if (!this.ModelState.IsValid)
            {
                return this.View(carWash);
            }

            try
            {
                await this.carWashService.AddCarWashRequestAsync(model, userId);
            }
            catch (Exception err)
            {
                this.ModelState.AddModelError("Key", err.Message);
                return this.View(carWash);
            }

            return this.Redirect("/");
        }

        public ActionResult Edit(int id)
        {
            return this.View();
        }

        // TODO: [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            return null;
        }
    }
}
