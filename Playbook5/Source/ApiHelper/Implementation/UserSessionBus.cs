using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using web.ApiHelper.Interface;

namespace web.ApiHelper.Implementation
{
    public class UserSessionBus : IUserSession
    {
        public string Username => ((ClaimsPrincipal)HttpContext.Current.User).FindFirst(ClaimTypes.Name) != null ?
            ((ClaimsPrincipal)HttpContext.Current.User).FindFirst(ClaimTypes.Name).Value : "";

        public string FullName => ((ClaimsPrincipal)HttpContext.Current.User).FindFirst("FirstName") != null ?
            ((ClaimsPrincipal)HttpContext.Current.User).FindFirst("FirstName").Value+ ","+((ClaimsPrincipal)HttpContext.Current.User).FindFirst("LastName").Value
            : "";
        public string BearerToken => ((ClaimsPrincipal) HttpContext.Current.User).FindFirst("AcessToken")!=null?
            ((ClaimsPrincipal)HttpContext.Current.User).FindFirst("AcessToken").Value:"";

        public List<string> Roles => ((ClaimsPrincipal)HttpContext.Current.User).FindFirst("Roles") != null ?
            new List<string>(((ClaimsPrincipal)HttpContext.Current.User).FindFirst("Roles").Value.Split(',')) : new List<string>(); 
    }
}
