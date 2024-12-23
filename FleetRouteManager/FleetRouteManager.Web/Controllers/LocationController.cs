﻿using FleetRouteManager.Common.Exceptions;
using FleetRouteManager.Services.Interfaces;
using FleetRouteManager.Web.Models.InputModels.LocationInputModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FleetRouteManager.Web.Controllers
{
    [Authorize]
    public class LocationController : Controller
    {
        private readonly ILocationService locationService;
        private readonly ICountryService countryService;
        private readonly IAddressService addressService;

        public LocationController(ILocationService locationService, ICountryService countryService, IAddressService addressService)
        {
            this.locationService = locationService;
            this.countryService = countryService;
            this.addressService = addressService;
        }

        [HttpGet("Locations")]
        public async Task<IActionResult> Index()
        {
            var model = await locationService.GetAllLocationsAsync();

            return View(model);
        }

        [HttpGet("Location Details")]
        public async Task<IActionResult> Details(int id)
        {
            var model = await locationService.GetLocationDetailsAsync(id);

            if (model == null)
            {
                TempData["LocationError"] = "Location was not found.";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet("Delete Location")]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await locationService.GetLocationDeleteModelAsync(id);

            if (model == null)
            {
                TempData["LocationError"] = "Location was not found.";
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
        [HttpPost("Delete Location")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            if (await locationService.DeleteLocationAsync(id))
            {
                TempData["LocationSucceed"] = "Location was deleted successfully.";
            }
            else
            {
                TempData["LocationError"] = "Something went wrong.";
            }

            return RedirectToAction("Index");
        }

        [HttpGet("Create New Location")]
        public async Task<IActionResult> Create()
        {

            await SetViewBagSelectListsAsync();
            var model = new LocationCreateInputModel();

            return View(model);
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpPost("Create New Location")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LocationCreateInputModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["LocationError"] = "There were validation errors.";

                await SetViewBagSelectListsAsync();
                return View(model);
            }

            try
            {
                await locationService.CreateNewLocationAsync(model);
                TempData["LocationSucceed"] = "Location was created successfully.";
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

        [HttpGet("Create New Location Modal")]
        public async Task<IActionResult> CreateModal()
        {

            await SetViewBagSelectListsAsync();
            var model = new LocationCreateInputModel();

            return PartialView(model);
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpPost("Create New Location Modal")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateModal(LocationCreateInputModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["LocationError"] = "There were validation errors.";

                await SetViewBagSelectListsAsync();
                return PartialView(model);
            }

            try
            {
                await locationService.CreateNewLocationAsync(model);
                TempData["LocationSucceed"] = "Location was created successfully.";
                return Json(new { success = true });

            }
            catch (CustomExistingEntityException e)
            {
                TempData["LocationError"] = e.Message;
                return Json(new { success = true });

            }
            catch (Exception)
            {
                TempData["LocationError"] = "An unexpected error occurred.";
                return Json(new { success = true });
            }
        }

        [HttpGet("Edit Location")]
        public async Task<IActionResult> Edit(int id)
        {

            await SetViewBagSelectListsAsync();

            var model = await locationService.GetLocationEditModelAsync(id);

            if (model is null)
            {
                TempData["LocationError"] = "Location was not found.";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpPost("Edit Location")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(LocationEditInputModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["LocationError"] = "There were validation errors.";

                await SetViewBagSelectListsAsync();
                return View(model);
            }

            try
            {
                if (await locationService.EditLocationAsync(model))
                {
                    TempData["LocationSucceed"] = "Location was edited successfully.";
                    return RedirectToAction("Details", new { model.Id });
                }
                else
                {
                    TempData["LocationError"] = "Location was not found.";
                }
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
            ViewBag.Countries = new SelectList(await countryService.GetCountryViewBagListAsync(), "Id", "Name");
            ViewBag.Addresses = new SelectList(await addressService.GetAddressViewBagListAsync(), "Id", "Name");
        }
    }
}
