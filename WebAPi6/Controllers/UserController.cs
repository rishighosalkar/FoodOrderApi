using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using WebAPi6.Helpers;
using WebAPi6.Middleware.Authorize;
using WebAPi6.Models;
using WebAPi6.Services;

namespace WebAPi6.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : Controller
    {
        private readonly IUser _user;
        public UserController(IUser user)
        {

            _user = user;

        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            string email = loginModel.Email; //"rushi@gmail.com";
            string password = loginModel.Password; //"rushikesh123#";
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)) {
                throw new ArgumentNullException("email");
            }

            return await _user.Login(email, password);
        }

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> SignUp([FromBody] User user)
        {
            return await _user.SignUp(user);
        }

        [HttpGet]
        //[Auth("Admin")]
        [Authorize]
        [Route("getAll")]
        public async Task<List<User>> GetAllUsers()
        { return await _user.GetAllUsers(); }
    }
}
