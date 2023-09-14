using Microsoft.AspNetCore.Mvc;
using WebAPi6.Models;

namespace WebAPi6.Services
{
    public interface IUser
    {
        public Task<IActionResult> SignUp(User user);
        public Task<IActionResult> Login(string email, string password);
        public Task<List<User>> GetAllUsers();
        public Task<IActionResult> GetUserById(int id);

    }
}
