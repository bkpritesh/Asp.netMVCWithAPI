using System.Web;
using web.ApiHelper;

namespace web.ApiInfrastructure
{
    public class TokenContainer : ITokenContainer
    {
        private const string ApiTokenKey = "ApiToken"; 
        public object ApiToken
        {
            get { return Current.Session != null ? Current.Session[ApiTokenKey] : null; }
            set { if (Current.Session != null) Current.Session[ApiTokenKey] = value; }
        }

        private static HttpContextBase Current
        {
            get { return new HttpContextWrapper(HttpContext.Current); }
        }
    }
}