using FleetRouteManager.Common.Exceptions;
using FleetRouteManager.Services.Interfaces;
using FleetRouteManager.Web.Models.InputModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FleetRouteManager.Web.Controllers
{
    [Authorize]
    public class DriverController : Controller
    {
        private readonly IDriverService driverService;

        public DriverController(IDriverService driverService)
        {
            this.driverService = driverService;
        }

        [HttpGet("Drivers")]
        public async Task<IActionResult> Index()
        {
            if (User.Identity?.IsAuthenticated != true)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = await driverService.GetAllDriversAsync();

            return View(model);
        }

        [HttpGet("Driver Details")]
        public async Task<IActionResult> Details(int id)
        {
            if (User.Identity?.IsAuthenticated != true)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = await driverService.GetDriverDetailsAsync(id);

            if (model == null)
            {
                //TODO: Vehicle not found!
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet("Delete Driver")]
        public async Task<IActionResult> Delete(int id)
        {
            if (User.Identity?.IsAuthenticated != true)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = await driverService.GetDriverDeleteModelAsync(id);

            if (model == null)
            {
                //TODO: Vehicle not found!
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

        [HttpPost("Delete Driver Confirmation")]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            if (User.Identity?.IsAuthenticated != true)
            {
                return RedirectToAction("Index", "Home");
            }

            await driverService.DeleteDriverAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet("Assign New Driver")]
        public IActionResult Assign()
        {
            if (User.Identity?.IsAuthenticated != true)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new DriverCreateInputModel();

            return View(model);
        }

        [HttpPost("Assign New Driver")]
        public async Task<IActionResult> Assign(DriverCreateInputModel model)
        {
            if (User.Identity?.IsAuthenticated != true)
            {
                return RedirectToAction("Index", "Home");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await driverService.AssignNewDriverAsync(model);
                return RedirectToAction("Index");
            }
            catch (CustomDateFormatException e)
            {
                ModelState.AddModelError(e.PropertyName, e.Message);

                return View(model);
            }

        }

        [HttpGet("Edit Driver")]
        public async Task<IActionResult> Edit(int id)
        {
            if (User.Identity?.IsAuthenticated != true)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = await driverService.GetDriverEditModelAsync(id);

            return View(model);
        }

        [HttpPost("Edit Driver")]
        public async Task<IActionResult> Edit(DriverEditInputModel model)
        {
            if (User.Identity?.IsAuthenticated != true)
            {
                return RedirectToAction("Index", "Home");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await driverService.EditDriverAsync(model);
                return RedirectToAction("Details", new { model.Id });
            }
            catch (CustomDateFormatException e)
            {
                ModelState.AddModelError(e.PropertyName, e.Message);

                return View(model);
            }

        }
    }
}
