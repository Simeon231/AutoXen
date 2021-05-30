namespace AutoXen.Web.Controllers
{
    using AutoXen.Web.ViewModels.Insurance;
    using Microsoft.AspNetCore.Mvc;

    public class InsuranceController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Index(InsuranceRequestViewModel input)
        {
            return this.View(new InsuranceRequestViewModel());
        }

        public IActionResult Details(int id)
        {
            return this.View();
        }
    }
}
