using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPi6.Context;
using WebAPi6.Models;
using WebAPi6.Services;

namespace WebAPi6.ServiceImp
{
    public class MealImp : Controller, IMeal
    {
        private readonly FoodOrderDBContext _foodOrderDBContext;
        public MealImp(FoodOrderDBContext foodOrderDBContext)
        {
            _foodOrderDBContext = foodOrderDBContext;
        }

        public async Task<IActionResult> AddMeals(Meal meal)
        {
            var chkExistingMeal = _foodOrderDBContext.Meals.FirstOrDefault(x => x.Name == meal.Name && x.RestaurantId == meal.RestaurantId);
            if (chkExistingMeal != null)
            {
                return new JsonResult(new
                {
                    statusCode = 409,
                    message = "Meal with name " + meal.Name + "already exist"
                });
            }

            await _foodOrderDBContext.Meals.AddAsync(meal);
            var result = await _foodOrderDBContext.SaveChangesAsync();

            return new JsonResult(new
            {
                StatusCode = 200,
                message = "Meal successfully added",
                meal = meal
            });
        }

        public async Task<IActionResult> GetMeals()
        {
            var meals = await _foodOrderDBContext.Meals.ToListAsync();
            if(meals == null)
            {
                return new JsonResult(new
                {
                    statusCode = 500,
                    message = "Unable to get meals",
                });
            }
            return Ok(new {
                statusCode = 200,
                message = "Meals retrieved",
                meals = meals 
            }) ;
        }

        public async Task<IActionResult> GetMealsByRestaurantId(int restaurantId)
        {
            var meals = await _foodOrderDBContext.Meals.Where(x => x.RestaurantId == restaurantId).ToListAsync();
            
            if (meals == null)
            {
                return new JsonResult(new
                {
                    statusCode = 500,
                    message = "Unable to get meals for restaurant",
                });
            }

            return Ok(new
            {
                statusCode = 200,
                message = "Meals retrieved",
                meals = meals
            });
        }
    }
}
