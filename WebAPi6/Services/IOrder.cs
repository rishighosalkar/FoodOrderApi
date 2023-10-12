using Microsoft.AspNetCore.Mvc;
using WebAPi6.Models;

namespace WebAPi6.Services
{
    public interface IOrder
    {
        public Task<IActionResult> CreateOrder(Order order);
        public Task<IActionResult> UpdateOrder(int orderId, Order order);
        public Task<IActionResult> GetOrders(int orderId);
    }
}
