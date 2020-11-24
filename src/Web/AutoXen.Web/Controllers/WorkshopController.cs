namespace AutoXen.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class WorkshopsController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
