using FleetRouteManager.Common.Exceptions;
using FleetRouteManager.Services.Interfaces;
using FleetRouteManager.Web.Models.InputModels.OrderInputModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FleetRouteManager.Web.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Manager")]
    public class ManagerOrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IClientService clientService;

        public ManagerOrderController(IOrderService orderService, IClientService clientService)
        {
            this.orderService = orderService;
            this.clientService = clientService;
        }


        [HttpGet("My Orders")]
        public async Task<IActionResult> Index()
        {
            var user = User.Identity!.Name;

            var model = await orderService.GetMyOrdersAsync(user!);

            return View(model);
        }

        [HttpGet("Delete My Order")]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await orderService.GetOrderDeleteModelAsync(id);

            if (model == null)
            {
                TempData["OrderError"] = "Order was not found.";
                return RedirectToAction("Index");
            }

            if (model.User != User.Identity!.Name!)
            {
                TempData["OrderError"] = "Order can be deleted by current order manager.";
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

        [HttpPost("Delete My Order")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            var user = User.Identity?.Name;

            if (await orderService.DeleteOrderAsync(id, user))
            {
                TempData["OrderSucceed"] = "Order was deleted successfully.";
            }
            else
            {
                TempData["OrderError"] = "Something went wrong.";
            }

            return RedirectToAction("Index");
        }

        [HttpGet("Create My New Order")]
        public async Task<IActionResult> Create()
        {

            await SetViewBagSelectListsAsync();
            var model = new OrderCreateInputModel
            {
                User = User.Identity!.Name!
            };

            return View(model);
        }

        [HttpPost("Create My New Order")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderCreateInputModel model)
        {
            if (model.User != User.Identity!.Name!)
            {
                TempData["OrderError"] = "An unexpected error occurred.";
                return RedirectToAction("Index");
            }

            if (!ModelState.IsValid)
            {
                TempData["OrderError"] = "There were validation errors.";

                await SetViewBagSelectListsAsync();
                return View(model);
            }

            try
            {
                await orderService.CreateNewOrderAsync(model);
                TempData["OrderSucceed"] = "Order was created successfully.";
            }
            catch (CustomExistingEntityException e)
            {
                TempData["OrderError"] = e.Message;
            }
            catch (Exception)
            {
                TempData["OrderError"] = "An unexpected error occurred.";
            }

            return RedirectToAction("Index", "ManagerOrder");
        }

        private async Task SetViewBagSelectListsAsync()
        {
            ViewBag.Clients = new SelectList(await clientService.GetClientViewBagListAsync(), "Id", "Name");
        }
    }
}
