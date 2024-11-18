using Microsoft.AspNetCore.Mvc;

namespace FleetRouteManager.Web.Controllers
{
    public class DriverController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
