using Microsoft.AspNetCore.Mvc;
using WebAPi6.Helpers;
using WebAPi6.Models;

namespace WebAPi6.Services
{
    public interface IOrder
    {
        public Task<IActionResult> CreateOrder(CreateOrder createOrder);
        public Task<IActionResult> UpdateOrder(Order order, Notification notificationModel);
        public Task<IActionResult> GetOrdersByUserId(int userId);
        public Task<IActionResult> GetOrderById(int orderId);
    }
}
