using Microsoft.AspNetCore.Mvc;
using WebAPi6.Services;

namespace WebAPi6.Controllers
{
    [ApiController]
    [Route("subcategory")]
    public class SubcategoryController : Controller
    {
        private readonly IMealSubcategory _mealSubcategory;
        public SubcategoryController(IMealSubcategory mealSubcategory)
        {
            _mealSubcategory = mealSubcategory;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            return await _mealSubcategory.GetAllSubcategory();
        }
    }
}
