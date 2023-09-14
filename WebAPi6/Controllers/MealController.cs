using Microsoft.AspNetCore.Mvc;
using WebAPi6.Models;
using WebAPi6.Services;

namespace WebAPi6.Controllers
{
    [ApiController]
    [Route("meals")]
    public class MealController : Controller
    {
        private readonly IMeal _meals;

        public MealController(IMeal meal)
        {
            _meals = meal;
        }

        [HttpGet]
        [Route("getAllMeals")]
        public async Task<IActionResult> GetMeals()
        {
            return await _meals.GetMeals();
        }
    }
}
