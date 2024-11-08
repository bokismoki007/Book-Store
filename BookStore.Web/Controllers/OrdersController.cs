using BookStore.Domain.Models.Domain;
using BookStore.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            var orders = _orderService.GetAllOrders();
            return View(orders);
        }
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var order = _orderService.GetDetailsForOrder(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }
    }
}
