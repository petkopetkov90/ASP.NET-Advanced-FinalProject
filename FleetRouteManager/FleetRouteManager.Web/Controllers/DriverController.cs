using FleetRouteManager.Common.Exceptions;
using FleetRouteManager.Services.Interfaces;
using FleetRouteManager.Web.Models.InputModels.DriverInputModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FleetRouteManager.Web.Controllers
{
    [Authorize]
    public class DriverController : Controller
    {
        private readonly IDriverService driverService;
        private readonly IVehicleService vehicleService;

        public DriverController(IDriverService driverService, IVehicleService vehicleService)
        {
            this.driverService = driverService;
            this.vehicleService = vehicleService;
        }

        [HttpGet("Drivers")]
        public async Task<IActionResult> Index()
        {
            var model = await driverService.GetAllDriversAsync();

            return View(model);
        }

        [HttpGet("Driver Details")]
        public async Task<IActionResult> Details(int id)
        {
            var model = await driverService.GetDriverDetailsAsync(id);

            if (model == null)
            {
                TempData["DriverError"] = "Driver was not found.";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet("Delete Driver")]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await driverService.GetDriverDeleteModelAsync(id);

            if (model == null)
            {
                TempData["DriverError"] = "Driver was not found.";
                return RedirectToAction("Index");
            }

            var returnUrl = Request.Headers["Referer"].ToString();

            if (string.IsNullOrEmpty(returnUrl))
            {
                returnUrl = Url.Action("Index", "Driver");
            }

            ViewData["ReturnUrl"] = returnUrl;

            return View("DeleteConfirmation", model);
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpPost("Delete Driver")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {

            if (await driverService.DeleteDriverAsync(id))
            {
                TempData["DriverSucceed"] = "Driver was deleted successfully.";
            }
            else
            {
                TempData["DriverError"] = "Something went wrong.";
            }

            return RedirectToAction("Index");
        }

        [HttpGet("Assign New Driver")]
        public async Task<IActionResult> Assign()
        {
            await SetViewBagSelectListsAsync();
            var model = new DriverCreateInputModel();

            return View(model);
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpPost("Assign New Driver")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Assign(DriverCreateInputModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["DriverError"] = "There were validation errors.";

                await SetViewBagSelectListsAsync();
                return View(model);
            }

            try
            {
                await driverService.AssignNewDriverAsync(model);
                TempData["DriverSucceed"] = "Driver was created successfully.";
            }
            catch (CustomDateFormatException e)
            {
                ModelState.AddModelError(e.PropertyName, e.Message);
                TempData["DriverError"] = "There were validation errors.";

                await SetViewBagSelectListsAsync();
                return View(model);
            }
            catch (CustomExistingEntityException e)
            {
                TempData["DriverError"] = e.Message;
            }
            catch (Exception)
            {
                TempData["DriverError"] = "An unexpected error occurred.";
            }

            return RedirectToAction("Index");

        }

        [HttpGet("Edit Driver")]
        public async Task<IActionResult> Edit(int id)
        {
            await SetViewBagSelectListsAsync();

            var model = await driverService.GetDriverEditModelAsync(id);

            if (model is null)
            {
                TempData["DriverError"] = "Driver was not found.";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpPost("Edit Driver")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DriverEditInputModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["DriverError"] = "There were validation errors.";

                await SetViewBagSelectListsAsync();
                return View(model);
            }

            try
            {
                if (await driverService.EditDriverAsync(model))
                {
                    TempData["DriverSucceed"] = "Driver was edited successfully.";
                    return RedirectToAction("Details", new { model.Id });
                }

                else
                {
                    TempData["DriverError"] = "Driver was not found.";
                }
            }
            catch (CustomDateFormatException e)
            {
                ModelState.AddModelError(e.PropertyName, e.Message);
                TempData["DriverError"] = "There were validation errors.";

                await SetViewBagSelectListsAsync();
                return View(model);
            }
            catch (CustomExistingEntityException e)
            {
                TempData["DriverError"] = e.Message;
            }
            catch (Exception)
            {
                TempData["DriverError"] = "An unexpected error occurred.";
            }

            return RedirectToAction("Index");

        }

        private async Task SetViewBagSelectListsAsync()
        {
            ViewBag.Vehicles = new SelectList(await vehicleService.GetVehicleViewBagListAsync(), "Id", "RegistrationNumber");
        }
    }
}
