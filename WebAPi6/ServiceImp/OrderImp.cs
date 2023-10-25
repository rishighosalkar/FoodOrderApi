using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPi6.Context;
using WebAPi6.Helpers;
using WebAPi6.Middleware.NotificationService;
using WebAPi6.Models;
using WebAPi6.Services;

namespace WebAPi6.ServiceImp
{
    public class OrderImp : Controller, IOrder
    {
        private readonly FoodOrderDBContext _foodOrderDBContext;
        private readonly INotificationService _notificationService;
        public OrderImp(FoodOrderDBContext foodOrderDBContext, INotificationService notificationService)
        {
            _foodOrderDBContext = foodOrderDBContext;
            _notificationService = notificationService;
        }
        public async Task<IActionResult> CreateOrder(CreateOrder createOrder)
        {
            try
            {
                var isNotificationSent = false;
                var orderData = createOrder.Order;
                var result = await _foodOrderDBContext.Orders.AddAsync(orderData);
                await _foodOrderDBContext.SaveChangesAsync();
                foreach (var cartItem in createOrder.Cart)
                {
                    cartItem.OrderId = orderData.OrderId;
                    _foodOrderDBContext.Carts.Update(cartItem);
                }
                _foodOrderDBContext.SaveChanges();
                var notificationResult = await _notificationService.SendNotification(createOrder.Notification);
                if(notificationResult.IsSuccess)
                {
                    isNotificationSent = true;
                }
                return new JsonResult(new
                {
                    statusCode = 200,
                    message = "Order added successfully",
                    isNotificationSent
                });
            }
            catch(Exception ex)
            {
                return new JsonResult(new
                {
                    statusCode = 400,
                    message = $"Failed to create order {ex.Message}"
                });
            }
        }

        public async Task<IActionResult> GetOrderById(int orderId)
        {
            try
            {
                var order = await _foodOrderDBContext.Orders.FirstOrDefaultAsync(o => o.OrderId == orderId);
                if(order == null)
                {
                    return new JsonResult(new
                    {
                        statusCode = 409,
                        message = "No data found"
                    });
                }
                return new JsonResult(new
                {
                    statusCode = 200,
                    message = "Data retreived successfully",
                    orderData = order
                });
            }
            catch(Exception ex)
            {
                return new JsonResult(new
                {
                    statusCode = 400,
                    message = $"Failed to get data {ex.Message}"
                });
            }
        }

        public async Task<IActionResult> GetOrdersByUserId(int customerId)
        {
            try
            {
                var orders = await _foodOrderDBContext.Orders.Where(o => o.UserId == customerId).ToListAsync();
                if (orders == null)
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
            catch(Exception ex)
            {
                return new JsonResult(new
                {
                    statusCode = 400,
                    message = $"Failed to get order data {ex.Message}"
                });
            }
            
        }

        public Task<IActionResult> UpdateOrder(Order order, Notification notificationModel)
        {
            throw new NotImplementedException();
        }
    }
}
