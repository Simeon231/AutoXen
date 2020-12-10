namespace AutoXen.Web.Areas.Administration.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AutoXen.Services.Data;
    using AutoXen.Web.ViewModels.Administration.CarWash;
    using Microsoft.AspNetCore.Mvc;

    public class CarWashesController : AdministrationController
    {
        private readonly ICarWashService carWashService;

        public CarWashesController(ICarWashService carWashService)
        {
            this.carWashService = carWashService;
        }

        public IActionResult Details(string id)
        {
            var model = this.carWashService.GetCarWashRequest(string.Empty, id, true);
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Details(AdminCarWashDetailsViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                var model = this.carWashService.GetCarWashRequest(string.Empty, input.Id, true);
                return this.View(model);
            }

            await this.carWashService.SubmitRequestAsync(input);

            return this.Redirect("/Administration/Requests");
        }
    }
}
