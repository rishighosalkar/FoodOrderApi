using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPi6.Context;
using WebAPi6.Models;
using WebAPi6.Services;

namespace WebAPi6.ServiceImp
{
    public class OrderImp : Controller, IOrder
    {
        private readonly FoodOrderDBContext _foodOrderDBContext;

        public OrderImp(FoodOrderDBContext foodOrderDBContext)
        {
            _foodOrderDBContext = foodOrderDBContext;
        }
        public async Task<IActionResult> CreateOrder(Order order)
        {
            var result = await _foodOrderDBContext.Orders.AddAsync(order);
            _foodOrderDBContext.SaveChanges();
            return new JsonResult(new
            {
                statusCode = 200,
                message = "Order added successfully"
            });
        }

        public async Task<IActionResult> GetOrders(int customerId)
        {
            var orders = await _foodOrderDBContext.Orders.Where(o => o.UserId == customerId).ToListAsync();
            if(orders == null)
            {
                return new JsonResult(new
                {
                    statusCode = 409,
                    message = "No order for the given customer",
                    customerId = customerId
                });
            }

            return new JsonResult(new
            {
                statusCode = 200,
                message = "Orders retrieved successfully",
                orders = orders
            });
        }

        public Task<IActionResult> UpdateOrder(int orderId, Order order)
        {
            throw new NotImplementedException();
        }
    }
}
