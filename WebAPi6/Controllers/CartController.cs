using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPi6.Models;
using WebAPi6.Services;

namespace WebAPi6.Controllers
{
    [ApiController]
    [Route("cart")]
    public class CartController : Controller
    {
        private readonly ICart _cart;
        public CartController(ICart cart)
        {
            _cart = cart;
        }

        [Authorize]
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(Cart cart)
        {
            return await _cart.AddToCart(cart);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get(int userId)
        {
            return await _cart.GetCartByUserId(userId);
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete(int cartId)
        {
            return await _cart.DeleteCart(cartId);
        }
    }
}
