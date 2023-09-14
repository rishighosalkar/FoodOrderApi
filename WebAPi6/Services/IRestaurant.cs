using Microsoft.AspNetCore.Mvc;
using WebAPi6.Models;

namespace WebAPi6.Services
{
    public interface IRestaurant
    {
        public Task<IActionResult> RegisterRestaurant(Restaurant restaurant);
        public Task<IActionResult> AddRestaurantMeal(string username, Meal meal);
        public Task<IActionResult> GetRestaurantDetails(string username, string password);
        public Task<List<Restaurant>> GetAllRestaurants();
        public Task<IActionResult> GetRestaurantNameById(int id);
    }
}
