using FleetRouteManager.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FleetRouteManager.Web.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Manager")]
    public class ManagerTripController : Controller
    {
        private readonly ITripService tripService;

        public ManagerTripController(ITripService tripService)
        {
            this.tripService = tripService;
        }

        [HttpGet("My Trip")]
        public async Task<IActionResult> Index()
        {
            var user = User.Identity!.Name;

            var model = await tripService.GetMyTripsAsync(user!);

            return View(model);
        }
    }
}
