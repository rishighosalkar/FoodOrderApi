using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPi6.Helpers;
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
        public async Task<IActionResult> GetAllRestaurants()
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
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            string email = loginModel.Email;
            string password = loginModel.Password;
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("email");
            }

            return await _restaurant.Login(email, password);
        }

        [HttpPost]
        [Route("addMeal")]
        public async Task<IActionResult> AddRestaurantMeal(string username, Meal meal)
        {
            return await _restaurant.AddRestaurantMeal(username, meal);
        }

        [HttpGet]
        [Route("getRestaurantNameById")]
        public async Task<IActionResult> GetRestaurantNameById(int id)
        {
            return await _restaurant.GetRestaurantNameById(id);
        }

    }
}
