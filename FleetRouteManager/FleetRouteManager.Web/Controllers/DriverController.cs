﻿using FleetRouteManager.Common.Exceptions;
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
                //TODO: Driver not found!
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
                //TODO: Driver not found!
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
            await driverService.DeleteDriverAsync(id);
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
                await SetViewBagSelectListsAsync();
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

                await SetViewBagSelectListsAsync();
                return View(model);
            }

        }

        [HttpGet("Edit Driver")]
        public async Task<IActionResult> Edit(int id)
        {
            await SetViewBagSelectListsAsync();

            var model = await driverService.GetDriverEditModelAsync(id);

            if (model is null)
            {
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
                await SetViewBagSelectListsAsync();
                return View(model);
            }

            try
            {
                if (!await driverService.EditDriverAsync(model))
                {
                    return RedirectToAction("Index");
                }

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
            ViewBag.Vehicles = new SelectList(await vehicleService.GetVehicleViewBagListAsync(), "Id", "RegistrationNumber");
        }
    }
}
