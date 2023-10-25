using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPi6.Context;
using WebAPi6.Models;
using WebAPi6.Services;

namespace WebAPi6.ServiceImp
{
    public class OrderConfirmationImp : Controller, IOrderConfirmation
    {
        private readonly FoodOrderDBContext _foodOrderDBContext;

        public OrderConfirmationImp(FoodOrderDBContext foodOrderDBContext)
        {
            _foodOrderDBContext = foodOrderDBContext;
        }
        public async Task<IActionResult> Add(OrderConfirmation orderConfirmation)
        {
            if (orderConfirmation == null)
            {
                return new JsonResult(new
                {
                    statusCode = 409,
                    message = "No data found"
                });
            }

            try
            {
                await _foodOrderDBContext.OrderConfirmation.AddAsync(orderConfirmation);
                _foodOrderDBContext.SaveChanges();

                return new JsonResult(new
                {
                    statusCode = 200,
                    message = "Added Successfully"
                });
            }
            catch (Exception ex)
            {
                return new JsonResult($"Failed to add {ex.Message}");
            }
            
        }

        public Task<IActionResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var orderConfirmation = await _foodOrderDBContext.OrderConfirmation.FirstOrDefaultAsync(x => x.ConfirmationId == id);
                if(orderConfirmation == null)
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
                    orderConfirmed = orderConfirmation.ConfirmStatus
                });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        public async Task<IActionResult> Update(OrderConfirmation orderConfirmation)
        {
            try
            {
                var orderConfirmed = await _foodOrderDBContext.OrderConfirmation.FirstOrDefaultAsync(x => x.ConfirmationId == orderConfirmation.ConfirmationId);
                if( orderConfirmed == null)
                {
                    return new JsonResult(new
                    {
                        statusCode = 409,
                        message = "No data found"
                    });
                }
                orderConfirmed.ConfirmStatus = orderConfirmation.ConfirmStatus;
                _foodOrderDBContext.OrderConfirmation.Update(orderConfirmed);
                await _foodOrderDBContext.SaveChangesAsync();
                return new JsonResult(new
                {
                    statusCode = 200,
                    message = "Updated successfully",
                    orderConfirmation = orderConfirmed
                });
            }
            catch( Exception ex)
            {
                return new JsonResult($"Failed to updated {ex.Message}");
            }

        }
    }
}
