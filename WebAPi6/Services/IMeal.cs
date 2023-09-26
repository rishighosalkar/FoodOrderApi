using Microsoft.AspNetCore.Mvc;
using WebAPi6.Migrations;
using WebAPi6.Models;

namespace WebAPi6.Services
{
    public interface IMeal
    {
        public Task<IActionResult> GetMeals();
        public Task<IActionResult> GetMealsByRestaurantId(int id);

        public Task<IActionResult> AddMeals(Meal meal);
    }
}
