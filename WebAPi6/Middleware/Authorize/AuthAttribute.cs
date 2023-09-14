using Microsoft.AspNetCore.Mvc;

namespace WebAPi6.Middleware.Authorize
{
    public class AuthAttribute : TypeFilterAttribute
    {
        public AuthAttribute(string role) : base(typeof(TypeFilterAttribute))
        {
            Arguments = new object[] { role };
        }
    }
}
