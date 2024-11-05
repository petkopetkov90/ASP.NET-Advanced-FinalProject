using FleetRouteManager.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace FleetRouteManager.Web.Controllers
{
    [Authorize]
    public class VehicleController : Controller
    {
        private readonly IVehicleService service;
        private readonly UserManager<IdentityUser> userManager;

        public VehicleController(IVehicleService service, UserManager<IdentityUser> userManager)
        {
            this.service = service;
            this.userManager = userManager;

        }

        [HttpGet("Vehicles")]
        public async Task<IActionResult> Index()
        {
            var userId = userManager.GetUserId(User);

            if (userId == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var vehicles = await service.GetAllVehicles();

            return View(vehicles);
        }

        //public async Task<IActionResult> Details(int id)
        //{
        //    var userId = userManager.GetUserId(User);

        //    if (userId == null)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }

        //    var model = await service.GetVehicleDetails(id);

        //    if (model == null)
        //    {
        //        return RedirectToAction("Index");
        //    }

        //    return View(model);
        //}
    }
}
