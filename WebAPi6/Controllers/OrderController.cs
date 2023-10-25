using Microsoft.AspNetCore.Mvc;
using WebAPi6.Helpers;
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
        [Route("add")]
        public async Task<IActionResult> Create(CreateOrder createOrder)
        {
            return await _order.CreateOrder(createOrder);
        }

        [HttpGet]
        [Route("user")]
        public async Task<IActionResult> GetOrdersByUserId(int customerId)
        {
            return await _order.GetOrdersByUserId(customerId);
        }
    }
}
