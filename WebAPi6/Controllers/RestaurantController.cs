using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPi6.Models;
using WebAPi6.Services;

namespace WebAPi6.Controllers
{
    [ApiController]
    [Route("restaurant")]
    public class RestaurantController : Controller
    {
        private readonly IRestaurant _restaurant;
        public RestaurantController(IRestaurant restaurant)
        {
            _restaurant = restaurant;
        }

        [HttpGet]
        [Route("getRestaurantList")]
        public async Task<List<Restaurant>> GetAllRestaurants()
        {
            return await _restaurant.GetAllRestaurants();
        }

        [HttpPost]
        [Route("registerRestaurant")]
        public async Task<IActionResult> RegisterRestaurant([FromBody] Restaurant restaurant)
        {
            return await _restaurant.RegisterRestaurant(restaurant);
        }

        [HttpPost]
        [Route("addMeal")]
        public async Task<IActionResult> AddRestaurantMeal(string username, Meal meal)
        {
            return await _restaurant.AddRestaurantMeal(username, meal);
        }
    }
}
