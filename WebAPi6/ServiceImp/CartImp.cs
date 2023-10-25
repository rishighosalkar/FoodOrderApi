using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPi6.Context;
using WebAPi6.Models;
using WebAPi6.Services;

namespace WebAPi6.ServiceImp
{
    public class CartImp : Controller, ICart
    {
        private readonly FoodOrderDBContext _foodOrderDBContext;
        public CartImp(FoodOrderDBContext foodOrderDBContext)
        {
            _foodOrderDBContext = foodOrderDBContext;
        }
        public async Task<IActionResult> AddToCart(Cart cart)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new
                {
                    statusCode=409
                });
            }
            var existingCartItem = await _foodOrderDBContext.Carts.FirstOrDefaultAsync(c => c.MealId == cart.MealId && c.UserId == cart.UserId && cart.OrderId != 0);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity++;
                //existingCartItem.TotalPrice += cart.TotalPrice;
                _foodOrderDBContext.Carts.Update(existingCartItem);
            }
            else
            {
                await _foodOrderDBContext.Carts.AddAsync(cart);
            }

            var result = await _foodOrderDBContext.SaveChangesAsync();

            return new JsonResult(new
            {
                statusCode = 200,
                message = "Item added successfully to cart",
                cartItem = cart
            });
        }

        public async Task<IActionResult> DeleteCart(int id)
        {
            var cartItem = await _foodOrderDBContext.Carts.FirstOrDefaultAsync(c => c.CartId == id);
            if(cartItem == null)
            {
                return new JsonResult(new
                {
                    statusCode = 400,
                    message = "No cart item found"
                });
            }

            if (cartItem.Quantity > 1)
                cartItem.Quantity--;

            else
                _foodOrderDBContext.Carts.Remove(cartItem);

            return new JsonResult(new
            {
                statusCode = 200,
                message = "Cart item deleted successfully"
            });

        }

        public async Task<IActionResult> GetCartByUserId(int userId)
        {
            var cartItems = await _foodOrderDBContext.Carts.Where(c => c.UserId == userId && c.OrderId == 0).ToListAsync();

            if (cartItems == null)
            {
                return new JsonResult(new
                {
                    statusCode = 409,
                    message = "No items in cart"
                });
            }

            return new JsonResult(new
            {
                statusCode = 200,
                cartItems = cartItems,
            });

        }

        public Task<IActionResult> UpdateCart(Cart cart)
        {
            throw new NotImplementedException();
        }
    }
}
