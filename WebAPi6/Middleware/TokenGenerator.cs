using Microsoft.AspNetCore.Mvc;
using WebAPi6.Helpers;
using WebAPi6.Models;
using WebAPi6.Services;

namespace WebAPi6.Middleware
{
    public class TokenGenerator<T>
    {
        private readonly ITokenGenerator _tokenGenerator;
        public TokenGenerator(ITokenGenerator tokenGenerator)
        {

            _tokenGenerator = tokenGenerator;

        }
        private string GetTokenId(LoginModel user)
        {
            var payload = new Dictionary<string, object>
            {
                //{"id",  user.UserId },
                {"username", user.Email},
                {"email", user.Email }

            };

            return _tokenGenerator.GenerateToken(payload);
        }

        private string GetAccessToken(LoginModel user)
        {
            var payload = new Dictionary<string, object>
            {
                {"username", user.Email},
                {"email", user.Email }

            };

            return _tokenGenerator.GenerateToken(payload);
        }
    }
}
