using Microsoft.AspNetCore.Mvc;
using WebAPi6.Models;

namespace WebAPi6.Services
{
    public interface ICart
    {
        public Task<IActionResult> AddToCart(Cart cart);
        public Task<IActionResult> UpdateCart(Cart cart);
        public Task<IActionResult> DeleteCart(int id);
        public Task<IActionResult> GetCartByUserId(int userId);
    }
}
