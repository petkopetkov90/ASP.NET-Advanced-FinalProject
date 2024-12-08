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
            if (User.Identity?.IsAuthenticated != true)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = await locationService.GetAllLocationsAsync();

            return View(model);
        }

        [HttpGet("Location Details")]
        public async Task<IActionResult> Details(int id)
        {
            if (User.Identity?.IsAuthenticated != true)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = await locationService.GetLocationDetailsAsync(id);

            if (model == null)
            {
                //TODO: Location not found!
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet("Delete Location")]
        public async Task<IActionResult> Delete(int id)
        {
            if (User.Identity?.IsAuthenticated != true)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = await locationService.GetLocationDeleteModelAsync(id);

            if (model == null)
            {
                //TODO: Vehicle not found!
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

        [HttpPost("Delete Location")]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            if (User.Identity?.IsAuthenticated != true)
            {
                return RedirectToAction("Index", "Home");
            }

            await locationService.DeleteLocationAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet("Create New Location")]
        public async Task<IActionResult> Create()
        {
            if (User.Identity?.IsAuthenticated != true)
            {
                return RedirectToAction("Index", "Home");
            }

            TempData["ReturnToAction"] = "Create";
            TempData["ReturnToController"] = "Location";
            TempData["ReturnToValue"] = null;


            await SetViewBagSelectListsAsync();
            var model = new LocationCreateInputModel();

            return View(model);
        }

        [HttpPost("Create New Location")]
        public async Task<IActionResult> Create(LocationCreateInputModel model)
        {
            if (User.Identity?.IsAuthenticated != true)
            {
                return RedirectToAction("Index", "Home");
            }

            if (!ModelState.IsValid)
            {
                TempData["ReturnToAction"] = "Create";
                TempData["ReturnToController"] = "Location";
                TempData["ReturnToValue"] = null;

                await SetViewBagSelectListsAsync();
                return View(model);
            }

            await locationService.CreateNewLocationAsync(model);
            return RedirectToAction("Index");


        }

        [HttpGet("Edit Location")]
        public async Task<IActionResult> Edit(int id)
        {
            if (User.Identity?.IsAuthenticated != true)
            {
                return RedirectToAction("Index", "Home");
            }

            TempData["ReturnToAction"] = "Edit";
            TempData["ReturnToController"] = "Location";
            TempData["ReturnToValue"] = id;

            await SetViewBagSelectListsAsync();

            var model = await locationService.GetLocationEditModelAsync(id);

            if (model is null)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost("Edit Location")]
        public async Task<IActionResult> Edit(LocationEditInputModel model)
        {
            if (User.Identity?.IsAuthenticated != true)
            {
                return RedirectToAction("Index", "Home");
            }

            if (!ModelState.IsValid)
            {
                TempData["ReturnToAction"] = "Edit";
                TempData["ReturnToController"] = "Location";
                TempData["ReturnToValue"] = model.Id;

                await SetViewBagSelectListsAsync();
                return View(model);
            }

            if (!await locationService.EditLocationAsync(model))
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Details", new { model.Id });
        }


        private async Task SetViewBagSelectListsAsync()
        {
            ViewBag.Countries = new SelectList(await countryService.GetCountryViewBagListAsync(), "Id", "Name");
            ViewBag.Addresses = new SelectList(await addressService.GetAddressViewBagListAsync(), "Id", "Name");
        }
    }
}
