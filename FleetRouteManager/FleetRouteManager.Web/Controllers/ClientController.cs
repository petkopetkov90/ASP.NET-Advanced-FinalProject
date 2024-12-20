using FleetRouteManager.Common.Exceptions;
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
                TempData["ClientError"] = "Client was not found.";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet("Client Details Partial")]
        public async Task<IActionResult> DetailsPartial(int id)
        {
            var model = await clientService.GetClientDetailsAsync(id);

            if (model == null)
            {
                return PartialView("_Error404");
            }

            return PartialView("DetailsPartial", model);
        }

        [HttpGet("Delete Client")]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await clientService.GetClientDeleteModelAsync(id);

            if (model == null)
            {
                TempData["ClientError"] = "Client was not found.";
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

            if (await clientService.DeleteClientAsync(id))
            {
                TempData["ClientSucceed"] = "Client was deleted successfully.";
            }
            else
            {
                TempData["ClientError"] = "Something went wrong.";
            }

            return RedirectToAction("Index");
        }

        [HttpGet("Add New Client")]
        public async Task<IActionResult> Add()
        {
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
                TempData["ClientError"] = "There were validation errors.";

                await SetViewBagSelectListsAsync();
                return View(model);
            }

            try
            {
                await clientService.CrateNewClientAsync(model);
                TempData["ClientSucceed"] = "Client was created successfully.";
            }
            catch (CustomExistingEntityException e)
            {
                TempData["ClientError"] = e.Message;
            }
            catch (Exception)
            {
                TempData["ClientError"] = "An unexpected error occurred.";
            }

            return RedirectToAction("Index");
        }


        [HttpGet("Edit Client")]
        public async Task<IActionResult> Edit(int id)
        {
            await SetViewBagSelectListsAsync();

            var model = await clientService.GetClientEditModelAsync(id);

            if (model is null)
            {
                TempData["ClientError"] = "Client was not found.";
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
                TempData["ClientError"] = "There were validation errors.";

                await SetViewBagSelectListsAsync();
                return View(model);
            }

            try
            {
                if (await clientService.EditClientAsync(model))
                {
                    TempData["ClientSucceed"] = "Client was edited successfully.";
                    return RedirectToAction("Details", new { model.Id });
                }
                else
                {
                    TempData["ClientError"] = "Client was not found.";
                }
            }
            catch (CustomExistingEntityException e)
            {
                TempData["ClientError"] = e.Message;
            }
            catch (Exception)
            {
                TempData["ClientError"] = "An unexpected error occurred.";
            }


            return RedirectToAction("Index");
        }

        private async Task SetViewBagSelectListsAsync()
        {
            ViewBag.Countries = new SelectList(await countryService.GetCountryViewBagListAsync(), "Id", "Name");
            ViewBag.Addresses = new SelectList(await addressService.GetAddressViewBagListAsync(), "Id", "Name");
            ViewBag.Locations = new SelectList(await locationService.GetLocationsViewBagListAsync(), "Id", "Name");
        }

    }
}
