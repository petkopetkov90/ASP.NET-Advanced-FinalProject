using FleetRouteManager.Common.Exceptions;
using FleetRouteManager.Services.Interfaces;
using FleetRouteManager.Web.Models.InputModels.AddressInputModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FleetRouteManager.Web.Controllers
{
    [Authorize]
    public class AddressController : Controller
    {
        private readonly IAddressService addressService;
        private readonly ICountryService countryService;

        public AddressController(IAddressService addressService, ICountryService countryService)
        {
            this.addressService = addressService;
            this.countryService = countryService;
        }

        [HttpGet("Add New Address")]
        public async Task<IActionResult> Add()
        {
            await SetViewBagSelectListsAsync();
            var model = new AddressCreateInputModel();

            return PartialView(model);
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpPost("Add New Address")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddressCreateInputModel model)
        {
            if (!ModelState.IsValid)
            {
                await SetViewBagSelectListsAsync();
                return PartialView(model);
            }

            try
            {
                TempData["AddressId"] = await addressService.AddNewAddressAsync(model);
                TempData["AddressSuccess"] = "Address was added successfully.";
                return Json(new { success = true });
            }
            catch (CustomExistingEntityException e)
            {
                TempData["AddressError"] = e.Message;
                return Json(new { success = true });

            }
            catch (Exception)
            {
                TempData["AddressError"] = "An unexpected error occurred.";
                return Json(new { success = true });

            }
        }


        private async Task SetViewBagSelectListsAsync()
        {
            ViewBag.Countries = new SelectList(await countryService.GetCountryViewBagListAsync(), "Id", "Name");
        }
    }
}
