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

        public VehicleController(IVehicleService vehicleService, IManufacturerService manufacturerService, IVehicleTypeService vehicleTypeService, UserManager<IdentityUser> userManager)
        {
            this.vehicleService = vehicleService;
            this.manufacturerService = manufacturerService;
            this.vehicleTypeService = vehicleTypeService;
        }

        [HttpGet("Vehicles")]
        public async Task<IActionResult> Index()
        {
            if (User.Identity?.IsAuthenticated != true)
            {
                return RedirectToAction("Index", "Home");
            }

            var vehicles = await vehicleService.GetAllVehiclesAsync();
            return View(vehicles);
        }


        [HttpGet("Vehicle Details")]
        public async Task<IActionResult> Details(int id)
        {
            if (User.Identity?.IsAuthenticated != true)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = await vehicleService.GetVehicleDetailsModelAsync(id);

            if (model == null)
            {
                //TODO: Vehicle not found!
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet("Delete Vehicle")]
        public async Task<IActionResult> Delete(int id)
        {
            if (User.Identity?.IsAuthenticated != true)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = await vehicleService.GetVehicleDeleteModelAsync(id);

            if (model == null)
            {
                //TODO: Vehicle not found!
                return RedirectToAction("Index");
            }

            var returnUrl = Request.Headers["Referer"].ToString();

            if (string.IsNullOrEmpty(returnUrl))
            {
                returnUrl = Url.Action("Index", "Vehicle");
            }

            ViewData["ReturnUrl"] = returnUrl;
            return View("DeleteConfirmation", model);
        }

        [HttpPost("Delete Vehicle Confirmation")]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            if (User.Identity?.IsAuthenticated != true)
            {
                return RedirectToAction("Index", "Home");
            }

            await vehicleService.DeleteVehicleAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet("Create Vehicle")]
        public async Task<IActionResult> Create()
        {
            if (User.Identity?.IsAuthenticated != true)
            {
                return RedirectToAction("Index", "Home");
            }

            await SetViewBagSelectListsAsync();
            var model = new VehicleCreateInputModel();
            return View(model);
        }

        [HttpPost("Create Vehicle")]
        public async Task<IActionResult> Create(VehicleCreateInputModel model)
        {
            if (User.Identity?.IsAuthenticated != true)
            {
                return RedirectToAction("Index", "Home");
            }

            if (!ModelState.IsValid)
            {
                await SetViewBagSelectListsAsync();
                return View(model);
            }

            try
            {
                await vehicleService.CreateNewVehicleAsync(model);
                return RedirectToAction("Index");
            }
            catch (CustomDateFormatException e)
            {
                ModelState.AddModelError(e.PropertyName, e.Message);

                await SetViewBagSelectListsAsync();
                return View(model);
            }

        }

        [HttpGet("Edit Vehicle")]
        public async Task<IActionResult> Edit(int id)
        {
            if (User.Identity?.IsAuthenticated != true)
            {
                return RedirectToAction("Index", "Home");
            }

            await SetViewBagSelectListsAsync();

            var model = await vehicleService.GetVehicleEditModelAsync(id);

            return View(model);
        }

        [HttpPost("Edit Vehicle")]
        public async Task<IActionResult> Edit(VehicleEditInputModel model)
        {
            if (User.Identity?.IsAuthenticated != true)
            {
                return RedirectToAction("Index", "Home");
            }

            if (!ModelState.IsValid)
            {
                await SetViewBagSelectListsAsync();
                return View(model);
            }

            try
            {
                await vehicleService.EditVehicleAsync(model);
                return RedirectToAction("Details", new { model.Id });
            }
            catch (CustomDateFormatException e)
            {
                ModelState.AddModelError(e.PropertyName, e.Message);

                await SetViewBagSelectListsAsync();
                return View(model);
            }

        }

        private async Task SetViewBagSelectListsAsync()
        {
            ViewBag.Manufacturers = new SelectList(await manufacturerService.GetAllManufacturersAsync(), "Id", "Name");
            ViewBag.VehicleTypes = new SelectList(await vehicleTypeService.GetAllTypesAsync(), "Id", "Type");
        }
    }
}
