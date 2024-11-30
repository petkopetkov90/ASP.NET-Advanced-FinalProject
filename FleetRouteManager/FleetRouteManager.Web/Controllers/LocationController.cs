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

        public LocationController(ILocationService locationService, ICountryService countryService)
        {
            this.locationService = locationService;
            this.countryService = countryService;
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
                //TODO: Vehicle not found!
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
                returnUrl = Url.Action("Index", "Location");
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

        [HttpGet("Add New Location")]
        public async Task<IActionResult> Create()
        {
            if (User.Identity?.IsAuthenticated != true)
            {
                return RedirectToAction("Index", "Home");
            }

            await SetViewBagSelectListsAsync();
            var model = new LocationCreateInputModel();

            return View(model);
        }

        [HttpPost("Add New Location")]
        public async Task<IActionResult> Create(LocationCreateInputModel model)
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

            await SetViewBagSelectListsAsync();

            var model = await locationService.GetLocationEditModelAsync(id);

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
                await SetViewBagSelectListsAsync();
                return View(model);
            }

            await locationService.EditLocationAsync(model);
            return RedirectToAction("Details", new { model.Id });
        }


        private async Task SetViewBagSelectListsAsync()
        {
            ViewBag.Countries = new SelectList(await countryService.GetCountryViewBagListAsync(), "Id", "Name");
        }
    }
}
