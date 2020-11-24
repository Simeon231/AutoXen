namespace AutoXen.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class RequestsController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
