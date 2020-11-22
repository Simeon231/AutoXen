namespace AutoXen.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AutoXen.Services;
    using AutoXen.Web.ViewModels;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class CarWashController : Controller
    {
        private readonly ICarWashService carWashService;

        public CarWashController(ICarWashService carWashService)
        {
            this.carWashService = carWashService;
        }

        // GET: CarWashController
        public ActionResult Index()
        {
            return null;
        }

        // GET: CarWashController/Details/5
        public ActionResult Details(int id)
        {
            return this.View();
        }

        public ActionResult Create()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var carWash = new CarWashRequestViewModel() { UserId = userId };

            return this.View(carWash);
        }

        // TODO: [Authorize] [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Create(CarWashRequestViewModel model)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!this.ModelState.IsValid)
            {
                var carWash = new CarWashRequestViewModel() { UserId = userId };

                return this.View(carWash);
            }

            await this.carWashService.AddCarWashRequestAsync(model, userId);

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
