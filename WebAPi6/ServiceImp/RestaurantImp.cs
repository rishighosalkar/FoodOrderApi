using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPi6.Context;
using WebAPi6.Middleware;
using WebAPi6.Models;
using WebAPi6.Services;

namespace WebAPi6.ServiceImp
{
    public class RestaurantImp : Controller, IRestaurant
    {
        private readonly FoodOrderDBContext _dbContext;
        private readonly ITokenGenerator _tokenGenerator;
        public RestaurantImp(FoodOrderDBContext dBContext, ITokenGenerator tokenGenerator)
        {
            _dbContext = dBContext;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<IActionResult> GetAllRestaurants()
        {
            
            List<Restaurant> restaurants = await _dbContext.Restaurants.ToListAsync();
            foreach(Restaurant restaurant in restaurants)
            {
                restaurant.RestaurantMeals = _dbContext.Meals.Where(x => x.RestaurantId == restaurant.RestaurantId).ToList();
                restaurant.Address = _dbContext.RestaurantAddresses.FirstOrDefault(x => x.RestaurantId == restaurant.RestaurantId);
            }
            return Ok(new
            {
                statusCode = 200,
                message = "Restaurant List",
                restaurants = restaurants
            }); ;
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
                return new JsonResult(new
                {
                    statusCode = 409,
                    message = "Restaurant already exist"
                });
            }

            foreach(var meal in restaurant.RestaurantMeals)
            {
                meal.RestaurantName = restaurant.RestaurantName;
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

        public async Task<IActionResult> Login(string email, string password)
        {
            Restaurant restaurant = await _dbContext.Restaurants.FirstOrDefaultAsync(x => x.RestaurantEmail == email && x.RestaurantPassword == password);
            if (restaurant == null)
            {
                return NotFound(new
                {
                    statusCode = 404,
                    message = "User not found!",
                });
            }
            return Ok(new
            {
                statusCode = 200,
                message = "User logged in successfully",
                accessToken = GetAccessToken(restaurant),
                restaurantData = restaurant
            });
        }

        public async Task<IActionResult> GetRestaurantNameById(int id)
        {
            Restaurant restaurant = await _dbContext.Restaurants.FirstOrDefaultAsync(x => x.RestaurantId == id);
            if(restaurant == null)
            {
                return new JsonResult(new
                {
                    statusCode = 404,
                    message = "Restaurant not found"
                });
            }

            return Ok(new
            {
                statusCode = 200,
                message = "Restaurant details",
                restaurantName = restaurant.RestaurantName
            });
        }

        [NonAction]
        private string GetTokenId(Restaurant restaurant)
        {
            var payload = new Dictionary<string, object>
            {
                //{"id",  user.UserId },
                {"username", restaurant.RestaurantUsername},
                {"email", restaurant.RestaurantEmail }
            };

            return _tokenGenerator.GenerateToken(payload);
        }

        [NonAction]
        private string GetAccessToken(Restaurant restaurant)
        {
            var payload = new Dictionary<string, object>
            {
                {"username", restaurant.RestaurantUsername},
                {"email", restaurant.RestaurantEmail }
            };

            return _tokenGenerator.GenerateToken(payload);
        }


    }
}
