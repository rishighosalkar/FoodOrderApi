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

        [HttpGet]
        [Route("getMealsResId")]
        public async Task<IActionResult> GetMealsByRestaurantId(int restaurantId)
        {
            return await _meals.GetMealsByRestaurantId(restaurantId);
        }

        [HttpPost]
        [Route("add-meal")]
        public async Task<IActionResult> AddMeal(Meal meal)
        {
            return await _meals.AddMeals(meal);
        }
    }
}
