using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPi6.Context;
using WebAPi6.Models;
using WebAPi6.Services;
using WebAPi6.TokenGenerator;

namespace WebAPi6.ServiceImp
{
    public class UserImp : Controller, IUser
    {
        private readonly FoodOrderDBContext _dBContext;
        private readonly ITokenGenerator _tokenGenerator;
        //private readonly TokenGeneratorService _tokenGeneratorService;
        public UserImp(FoodOrderDBContext dBContext, ITokenGenerator tokenGenerator) // TokenGeneratorImp tokenGenerator)
        {
            _dBContext = dBContext;
            //_tokenGeneratorService = tokenGeneratorService;
            _tokenGenerator = tokenGenerator;
        }
        public async Task<List<User>> GetAllUsers()
        {
            return await _dBContext.Users.ToListAsync();
        }

        public async Task<IActionResult> GetUserById(int id)
        {
            User user = await _dBContext.Users.FirstOrDefaultAsync(x => x.UserId == id);
            if (user == null)
            {
                return NotFound(new
                {
                    statusCode = 404,
                    message = "User not found!"
                });
            }
            return Ok(new
            {
                statusCode = 200,
                user = user
            });
        }

        public async Task<IActionResult> Login(string email, string password)
        {
            User user = await _dBContext.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
            if(user == null)
            {
                return NotFound(new
                {
                    statusCode = 404,
                    message = "User not found!",
                });
            }
            user.Address = await _dBContext.UserAddresses.FirstOrDefaultAsync(add => add.UserId == user.UserId);

            return Ok(new
            {
                statusCode = 200,
                message = "User logged in successfully",
                accessToken = GetAccessToken(user),
                userData = user
            });
        }

        public async Task<IActionResult> SignUp(User user)
        {

            //_dBContext.Users.FindAsync(user);
            User chkExistingUser = _dBContext.Users.FirstOrDefault(x => x.UserName == user.UserName ||  x.Email == user.Email);
            if (chkExistingUser != null)
            {
                return new JsonResult(new
                {
                    statusCode = 409,
                    message = "User already exist",
                    username = user.UserName
                });
            }

            await _dBContext.Users.AddAsync(user);
            await _dBContext.SaveChangesAsync();
            
            return Ok(new
            {
                statusCode = 200,
                message = "User signed up successfully",
                accessToken = GetAccessToken(user),
                userData = user
            });

        }

        [NonAction]
        private string GetTokenId(User user)
        {
            var payload = new Dictionary<string, object>
            {
                //{"id",  user.UserId },
                {"username", user.UserName},
                {"email", user.Email }
                
            };

            return _tokenGenerator.GenerateToken(payload);
        }

        [NonAction]
        private string GetAccessToken(User user)
        {
            var payload = new Dictionary<string, object>
            {
                {"username", user.UserName},
                {"email", user.Email }

            };

            return _tokenGenerator.GenerateToken(payload);
        }
    }
}
