using Microsoft.AspNetCore.Mvc;
using WebAPi6.Models;
using WebAPi6.Services;

namespace WebAPi6.Controllers
{
    [ApiController]
    [Route("order")]
    public class OrderController : Controller
    {
        private readonly IOrder _order;
        public OrderController(IOrder order)
        {
            _order = order;
        }

        [HttpPost]
        [Route("create-order")]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            return await _order.CreateOrder(order);
        }

        [HttpGet]
        [Route("get-orders")]
        public async Task<IActionResult> GetOrders(int customerId)
        {
            return await _order.GetOrders(customerId);
        }
    }
}
