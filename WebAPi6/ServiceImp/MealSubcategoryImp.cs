using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPi6.Context;
using WebAPi6.Models;
using WebAPi6.Services;

namespace WebAPi6.ServiceImp
{
    public class MealSubcategoryImp : Controller, IMealSubcategory
    {
        private readonly FoodOrderDBContext _dbContext;
        public MealSubcategoryImp(FoodOrderDBContext foodOrderDBContext)
        {
            _dbContext = foodOrderDBContext;
        }
        public Task<IActionResult> AddSubcategory(Subcategory subcategory)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> GetAllSubcategory()
        {
            var subcategoryList = await _dbContext.Subcategories.ToListAsync();
            if (subcategoryList == null)
            {
                return new JsonResult(new
                {
                    statusCode = 404,
                    message = "Subcategories not found"
                });
            }

            return Ok(new
            {
                statusCode = 200,
                message = "Subcategory details",
                subcategoryList = subcategoryList
            });
        }
    }
}
