using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPi6.Middleware.Authorize
{
    public class AuthAction : IAuthorizationFilter
    {
        private string _role;
        public AuthAction(string role)
        {
            _role = role;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string roleType = context.HttpContext.Request.Headers["role"].ToString();
            if(!string.IsNullOrEmpty(roleType) || roleType.ToUpper() != "ADMIN")
            {
                context.Result = new JsonResult("Permission Denied!");
            }
        }
    }
}
