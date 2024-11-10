using FleetRouteManager.Common.Exceptions;
using FleetRouteManager.Services.Interfaces;
using FleetRouteManager.Web.Models.InputModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace FleetRouteManager.Web.Controllers
{
    [Authorize]
    public class VehicleController : Controller
    {
        private readonly IVehicleService vehicleService;
        private readonly IManufacturerService manufacturerService;
        private readonly IVehicleTypeService vehicleTypeService;
        private readonly UserManager<IdentityUser> userManager;

        public VehicleController(IVehicleService vehicleService, IManufacturerService manufacturerService, IVehicleTypeService vehicleTypeService, UserManager<IdentityUser> userManager)
        {
            this.vehicleService = vehicleService;
            this.manufacturerService = manufacturerService;
            this.vehicleTypeService = vehicleTypeService;
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

            var vehicles = await vehicleService.GetAllVehiclesAsync();

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

            var model = await vehicleService.GetVehicleDetailsModelAsync(id);

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

            var model = await vehicleService.GetVehicleDeleteModelAsync(id);

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

            await vehicleService.DeleteVehicleAsync(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var userId = userManager.GetUserId(User);

            if (userId == null)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Manufacturers = new SelectList(await manufacturerService.GetAllManufacturersAsync(), "Id", "Name");
            ViewBag.VehicleTypes = new SelectList(await vehicleTypeService.GetAllTypesAsync(), "Id", "Type");

            var model = new VehicleCreateInputModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(VehicleCreateInputModel model)
        {
            var userId = userManager.GetUserId(User);

            if (userId == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (!ModelState.IsValid)
            {

                ViewBag.Manufacturers = new SelectList(await manufacturerService.GetAllManufacturersAsync(), "Id", "Name");
                ViewBag.VehicleTypes = new SelectList(await vehicleTypeService.GetAllTypesAsync(), "Id", "Type");

                return View(model);
            }

            try
            {
                await vehicleService.AddNewVehicle(model);
                return RedirectToAction("Index");
            }
            catch (CustomDateFormatException e)
            {
                ModelState.AddModelError(e.PropertyName, e.Message);

                ViewBag.Manufacturers = new SelectList(await manufacturerService.GetAllManufacturersAsync(), "Id", "Name");
                ViewBag.VehicleTypes = new SelectList(await vehicleTypeService.GetAllTypesAsync(), "Id", "Type");

                return View(model);
            }
        }
    }
}
