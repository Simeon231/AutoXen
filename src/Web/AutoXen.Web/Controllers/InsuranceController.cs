namespace AutoXen.Web.Controllers
{
    using AutoXen.Web.ViewModels.Insurance;
    using Microsoft.AspNetCore.Mvc;

    public class InsuranceController : Controller
    {
        public ActionResult Index()
        {
            return this.View(new InsuranceRequestViewModel());
        }

        public ActionResult Details(int id)
        {
            return this.View();
        }

        public ActionResult Create()
        {
            return this.View();
        }
    }
}
