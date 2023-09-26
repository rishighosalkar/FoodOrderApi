using Microsoft.AspNetCore.Mvc;
using WebAPi6.Models;

namespace WebAPi6.Services
{
    public interface IMealSubcategory
    {
        public Task<IActionResult> AddSubcategory(Subcategory subcategory);
        public Task<IActionResult> GetAllSubcategory();
    }
}
