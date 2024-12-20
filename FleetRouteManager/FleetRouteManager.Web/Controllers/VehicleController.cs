using FleetRouteManager.Common.Exceptions;
using FleetRouteManager.Services.Interfaces;
using FleetRouteManager.Web.Models.InputModels.VehicleInputModels;
using Microsoft.AspNetCore.Authorization;
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

        public VehicleController(IVehicleService vehicleService, IManufacturerService manufacturerService, IVehicleTypeService vehicleTypeService)
        {
            this.vehicleService = vehicleService;
            this.manufacturerService = manufacturerService;
            this.vehicleTypeService = vehicleTypeService;
        }

        [HttpGet("Vehicles")]
        public async Task<IActionResult> Index()
        {
            var vehicles = await vehicleService.GetAllVehiclesAsync();

            return View(vehicles);
        }


        [HttpGet("Vehicle Details")]
        public async Task<IActionResult> Details(int id)
        {
            var model = await vehicleService.GetVehicleDetailsModelAsync(id);

            if (model == null)
            {
                TempData["VehicleError"] = "Vehicle was not found.";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet("Vehicle Details Partial")]
        public async Task<IActionResult> DetailsPartial(int id)
        {
            var model = await vehicleService.GetVehicleDetailsModelAsync(id);

            if (model == null)
            {

                return PartialView("_Error404");
            }

            return PartialView(model);
        }

        [HttpGet("Delete Vehicle")]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await vehicleService.GetVehicleDeleteModelAsync(id);

            if (model == null)
            {
                TempData["VehicleError"] = "Vehicle was not found.";
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

        [Authorize(Roles = "Admin, Manager")]
        [HttpPost("Delete Vehicle")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {

            if (await vehicleService.DeleteVehicleAsync(id))
            {
                TempData["VehicleSucceed"] = "Vehicle was deleted successfully.";
            }
            else
            {
                TempData["VehicleError"] = "Something went wrong.";
            }

            return RedirectToAction("Index");
        }

        [HttpGet("Create Vehicle")]
        public async Task<IActionResult> Create()
        {
            await SetViewBagSelectListsAsync();
            var model = new VehicleCreateInputModel();

            return View(model);
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpPost("Create Vehicle")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VehicleCreateInputModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["VehicleError"] = "There were validation errors.";

                await SetViewBagSelectListsAsync();
                return View(model);
            }

            try
            {
                await vehicleService.CreateNewVehicleAsync(model);
                TempData["VehicleSucceed"] = "Vehicle was created successfully.";
            }
            catch (CustomDateFormatException e)
            {
                ModelState.AddModelError(e.PropertyName, e.Message);
                TempData["VehicleError"] = "There were validation errors.";

                await SetViewBagSelectListsAsync();
                return View(model);
            }
            catch (CustomExistingEntityException e)
            {
                TempData["VehicleError"] = e.Message;
            }
            catch (Exception)
            {
                TempData["VehicleError"] = "An unexpected error occurred.";
            }

            return RedirectToAction("Index");

        }

        [HttpGet("Edit Vehicle")]
        public async Task<IActionResult> Edit(int id)
        {
            await SetViewBagSelectListsAsync();

            var model = await vehicleService.GetVehicleEditModelAsync(id);

            if (model is null)
            {
                TempData["VehicleError"] = "Vehicle was not found.";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpPost("Edit Vehicle")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(VehicleEditInputModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["VehicleError"] = "There were validation errors.";

                await SetViewBagSelectListsAsync();
                return View(model);
            }

            try
            {
                if (await vehicleService.EditVehicleAsync(model))
                {
                    TempData["VehicleSucceed"] = "Vehicle was edited successfully.";
                    return RedirectToAction("Details", new { model.Id });
                }

                else
                {
                    TempData["VehicleError"] = "Vehicle was not found.";
                }
            }
            catch (CustomDateFormatException e)
            {
                ModelState.AddModelError(e.PropertyName, e.Message);
                TempData["VehicleError"] = "There were validation errors.";


                await SetViewBagSelectListsAsync();
                return View(model);
            }
            catch (CustomExistingEntityException e)
            {
                TempData["LocationError"] = e.Message;
            }
            catch (Exception)
            {
                TempData["LocationError"] = "An unexpected error occurred.";
            }

            return RedirectToAction("Index");
        }

        private async Task SetViewBagSelectListsAsync()
        {
            ViewBag.Manufacturers = new SelectList(await manufacturerService.GetManufacturersViewBagListAsync(), "Id", "Name");
            ViewBag.VehicleTypes = new SelectList(await vehicleTypeService.GetVehicleTypeViewBagListAsync(), "Id", "Type");
        }
    }
}
