using FleetRouteManager.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FleetRouteManager.Web.Controllers
{
    [Authorize]
    public class LocationController : Controller
    {
        private readonly ILocationService locationService;

        public LocationController(ILocationService locationService)
        {
            this.locationService = locationService;
        }

        public async Task<IActionResult> Index()
        {
            if (!User.Identity?.IsAuthenticated != true)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = await locationService.GetAllLocationsAsync();

            return View(model);
        }
    }
}
