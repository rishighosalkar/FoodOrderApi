using Microsoft.AspNetCore.Mvc;
using WebAPi6.Models;

namespace WebAPi6.Services
{
    public interface IMeal
    {
        public Task<IActionResult> GetMeals();
    }
}
