using FleetRouteManager.Services.Interfaces;
using FleetRouteManager.Web.Models.InputModels.AddressInputModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FleetRouteManager.Web.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressService addressService;
        private readonly ICountryService countryService;

        public AddressController(IAddressService addressService, ICountryService countryService)
        {
            this.addressService = addressService;
            this.countryService = countryService;
        }

        //[HttpGet("Add New Address")]
        //public async Task<IActionResult> Add()
        //{
        //    if (User.Identity?.IsAuthenticated != true)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }

        //    await SetViewBagSelectListsAsync();
        //    var model = new AddressCreateInputModel();

        //    return View(model);
        //}

        //[HttpPost("Add New Address")]
        //public async Task<IActionResult> Add(AddressCreateInputModel model)
        //{
        //    if (User.Identity?.IsAuthenticated != true)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        await SetViewBagSelectListsAsync();
        //        return View(model);
        //    }

        //    await addressService.AddNewAddressAsync(model);

        //    return RedirectToAction("Index", "Address");
        //}

        [HttpPost("Add New Address")]
        public async Task<IActionResult> _AddNewAddressModalPartial(AddressCreateInputModel model)
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

            await addressService.AddNewAddressAsync(model);

            var returnUrl = Request.Headers["Referer"].ToString();

            if (!string.IsNullOrEmpty(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }

        private async Task SetViewBagSelectListsAsync()
        {
            ViewBag.Countries = new SelectList(await countryService.GetCountryViewBagListAsync(), "Id", "Name");
        }
    }
}
