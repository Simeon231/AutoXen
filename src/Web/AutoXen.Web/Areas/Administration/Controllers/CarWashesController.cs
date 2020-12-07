namespace AutoXen.Web.Areas.Administration.Controllers
{
    using AutoXen.Services.Data;
    using Microsoft.AspNetCore.Mvc;

    public class CarWashesController : AdministrationController
    {
        private readonly ICarWashService carWashService;

        public CarWashesController(ICarWashService carWashService)
        {
            this.carWashService = carWashService;
        }

        public IActionResult Details(string requestId)
        {
            return this.View();
        }
    }
}
