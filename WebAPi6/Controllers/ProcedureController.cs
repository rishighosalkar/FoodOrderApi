using Microsoft.AspNetCore.Mvc;

namespace WebAPi6.Controllers
{
    public class ProcedureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
