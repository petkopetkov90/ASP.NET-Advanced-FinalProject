using FleetRouteManager.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FleetRouteManager.Web.Controllers
{
    [Authorize]
    public class TripController : Controller
    {
        private readonly ITripService tripService;

        public TripController(ITripService tripService)
        {
            this.tripService = tripService;
        }

        [HttpGet("Trips")]
        public async Task<IActionResult> Index()
        {
            var model = await tripService.GetAllTripsAsync();

            return View(model);
        }

        [HttpGet("Trip Details")]
        public async Task<IActionResult> Details(int id)
        {
            var model = await tripService.GetTripDetailsAsync(id);

            if (model == null)
            {
                TempData["TripError"] = "Trip was not found.";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet("Trip Details Partial")]
        public async Task<IActionResult> DetailsPartial(int id)
        {

            var model = await tripService.GetTripDetailsAsync(id);

            if (model == null)
            {

                return PartialView("_Error404");
            }

            return PartialView(model);
        }

        [HttpGet("Delete Trip")]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await tripService.GetTripDeleteModelAsync(id);

            if (model == null)
            {
                TempData["TripError"] = "Trip was not found.";
                return RedirectToAction("Index");
            }

            if (User.Identity?.Name != "admin@myapp.com" && model.User != User.Identity?.Name)
            {
                TempData["TripError"] = "Trip can be deleted by current trip manager.";
                return RedirectToAction("Index");
            }

            var returnUrl = Request.Headers["Referer"].ToString();

            if (string.IsNullOrEmpty(returnUrl))
            {
                returnUrl = Url.Action("Index");
            }

            ViewData["ReturnUrl"] = returnUrl;

            return View("DeleteConfirmation", model);
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpPost("Delete Trip")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            var user = User.Identity?.Name;

            if (await tripService.DeleteTripAsync(id, user))
            {
                TempData["TripSucceed"] = "Trip was deleted successfully.";
            }
            else
            {
                TempData["TripError"] = "Something went wrong.";
            }

            return RedirectToAction("Index");
        }
    }
}
