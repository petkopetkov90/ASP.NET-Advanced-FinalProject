using FleetRouteManager.Services.Interfaces;
using FleetRouteManager.Web.Models.InputModels.ClientInputModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FleetRouteManager.Web.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        private readonly IClientService clientService;
        private readonly ICountryService countryService;
        private readonly IAddressService addressService;
        private readonly ILocationService locationService;

        public ClientController(IClientService clientService, ICountryService countryService, IAddressService addressService, ILocationService locationService)
        {
            this.clientService = clientService;
            this.countryService = countryService;
            this.addressService = addressService;
            this.locationService = locationService;
        }

        [HttpGet("Clients")]
        public async Task<IActionResult> Index()
        {
            var model = await clientService.GetAllClientsAsync();

            return View(model);
        }

        [HttpGet("Client Details")]
        public async Task<IActionResult> Details(int id)
        {
            var model = await clientService.GetClientDetailsAsync(id);


            if (model == null)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet("Delete Client")]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await clientService.GetClientDeleteModelAsync(id);

            if (model == null)
            {
                //TODO: Driver not found!
                return RedirectToAction("Index");
            }

            var returnUrl = Request.Headers["Referer"].ToString();

            if (string.IsNullOrEmpty(returnUrl))
            {
                returnUrl = Url.Action("Index", "Client");
            }

            ViewData["ReturnUrl"] = returnUrl;

            return View("DeleteConfirmation", model);
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpPost("Delete Client")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            await clientService.DeleteClientAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet("Add New Client")]
        public async Task<IActionResult> Add()
        {
            TempData["ReturnToAction"] = "Add";
            TempData["ReturnToController"] = "Client";
            TempData["ReturnToValue"] = null;

            await SetViewBagSelectListsAsync();
            var model = new ClientCreateInputModel();

            return View(model);
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpPost("Add New Client")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ClientCreateInputModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ReturnToAction"] = "Add";
                TempData["ReturnToController"] = "Client";
                TempData["ReturnToValue"] = null;
                await SetViewBagSelectListsAsync();
                return View(model);
            }


            await clientService.CrateNewClientAsync(model);
            return RedirectToAction("Index");

        }


        [HttpGet("Edit Client")]
        public async Task<IActionResult> Edit(int id)
        {
            TempData["ReturnToAction"] = "Edit";
            TempData["ReturnToController"] = "Client";
            TempData["ReturnToValue"] = id;

            await SetViewBagSelectListsAsync();

            var model = await clientService.GetClientEditModelAsync(id);

            if (model is null)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpPost("Edit Client")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ClientEditInputModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ReturnToAction"] = "Edit";
                TempData["ReturnToController"] = "Client";
                TempData["ReturnToValue"] = model.Id;

                await SetViewBagSelectListsAsync();
                return View(model);
            }

            if (!await clientService.EditClientAsync(model))
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Details", new { model.Id });
        }

        private async Task SetViewBagSelectListsAsync()
        {
            ViewBag.Countries = new SelectList(await countryService.GetCountryViewBagListAsync(), "Id", "Name");
            ViewBag.Addresses = new SelectList(await addressService.GetAddressViewBagListAsync(), "Id", "Name");
            ViewBag.Locations = new SelectList(await locationService.GetLocationsViewBagListAsync(), "Id", "Name");
        }

    }
}
