using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPi6.Context;
using WebAPi6.Models;
using WebAPi6.Services;

namespace WebAPi6.ServiceImp
{
    public class RestaurantImp : Controller, IRestaurant
    {
        private readonly FoodOrderDBContext _dbContext;
        public RestaurantImp(FoodOrderDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<List<Restaurant>> GetAllRestaurants()
        {
            
            List<Restaurant> restaurants = await _dbContext.Restaurants.ToListAsync();
            foreach(Restaurant restaurant in restaurants)
            {
                restaurant.RestaurantMeals = _dbContext.Meals.Where(x => x.RestaurantId == restaurant.RestaurantId).ToList();
                restaurant.Address = _dbContext.RestaurantAddresses.FirstOrDefault(x => x.RestaurantId == restaurant.RestaurantId);
            }
            return restaurants;
        }
        public async Task<IActionResult> AddRestaurantMeal(string username, Meal meal)
        {
            Restaurant restaurant = await _dbContext.Restaurants.FirstOrDefaultAsync(x => x.RestaurantUsername == username);

            if (restaurant == null)
            {
                return NotFound(new
                {
                    statusCode = 404,
                    message = "Restaurant not found!"
                });
            }

            restaurant.RestaurantMeals.Add(meal);
            _dbContext.Restaurants.Update(restaurant);
            await _dbContext.SaveChangesAsync();
            return Ok(new
            {
                statusCode = 200,
                message = "Meal added successfully",
                name = restaurant.RestaurantName
            });
        }

        public Task<IActionResult> GetRestaurantDetails(string username, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> RegisterRestaurant(Restaurant restaurant)
        {
            Restaurant chkExistingRestaurant = await _dbContext.Restaurants.FirstOrDefaultAsync(x => x.RestaurantUsername == restaurant.RestaurantUsername || x.RestaurantName == restaurant.RestaurantName);
            
            if(chkExistingRestaurant != null)
            {
                return BadRequest(new
                {
                    statusCode = 409,
                    message = "Restaurant already exist"
                });
            }

            await _dbContext.AddAsync(restaurant);

            await _dbContext.SaveChangesAsync();

            return Ok(new
            {
                statusCode = 200,
                message = "Restaurant Registered Successfully",
                username = restaurant.RestaurantUsername
            });
        }
    }
}
