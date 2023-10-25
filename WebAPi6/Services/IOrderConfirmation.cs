using Microsoft.AspNetCore.Mvc;
using WebAPi6.Models;

namespace WebAPi6.Services
{
    public interface IOrderConfirmation
    {
        public Task<IActionResult> Add(OrderConfirmation orderConfirmation);
        public Task<IActionResult> Delete(int id);
        public Task<IActionResult> Update(OrderConfirmation orderConfirmation);
        public Task<IActionResult> GetById(int id);
    }
}
