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

            var vehicles = await service.GetAllVehiclesAsync();

            return View(vehicles);
        }

        [HttpGet("Details")]
        public async Task<IActionResult> Details(int id)
        {
            var userId = userManager.GetUserId(User);

            if (userId == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = await service.GetVehicleDetailModelAsync(id);

            if (model == null)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = userManager.GetUserId(User);

            if (userId == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = await service.GetVehicleDeleteModelAsync(id);

            if (model == null)
            {
                return RedirectToAction("Index");
            }

            var returnUrl = Request.Headers?["Referer"].ToString();

            if (String.IsNullOrEmpty(returnUrl))
            {
                returnUrl = Url.Action("Index", "Vehicle");
            }

            ViewData["ReturnUrl"] = returnUrl;

            return View("DeleteConfirmation", model);
        }

        [HttpPost("DeleteConfirmation")]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            var userId = userManager.GetUserId(User);

            if (userId == null)
            {
                return RedirectToAction("Index", "Home");
            }

            await service.DeleteVehicleAsync(id);

            return RedirectToAction("Index");
        }
    }
}
