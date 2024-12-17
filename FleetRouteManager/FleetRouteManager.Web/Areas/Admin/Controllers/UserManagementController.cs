using Microsoft.AspNetCore.Mvc;

namespace FleetRouteManager.Web.Areas.Admin.Controllers
{
    public class UserManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
