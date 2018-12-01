#region

using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using web.ApiHelper.Client;
using web.ApiHelper.Implementation;
using web.ApiHelper.Response;
using web.ApiInfrastructure;
using web.ApiInfrastructure.Client;
using web.ApiInfrastructure.Responses;
using web.Models.Authorize;

#endregion

namespace web.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        private readonly ILoginClient _loginClient; 
        private readonly UserSessionBus _userSessionBus = new UserSessionBus();
        public AccountController()
        {
            var apiClient = new ApiClient(HttpClientInstance.Instance);
            _loginClient = new LoginClient(apiClient);
        }

        public ActionResult LogOn(string ReturnUrl = null)
        {
           

            if (Request.IsAuthenticated)
            {
                if (_userSessionBus.Roles.Any(m => m.ToUpper() == "COACH"))
                {
                    return RedirectToAction("teams", "TeamManagement", new { area = "Management" });
                }
                return RedirectToAction("Games", "Home");
            }
            if (string.IsNullOrEmpty(ReturnUrl) && Request.UrlReferrer != null)
                ReturnUrl = Server.UrlEncode(Request.UrlReferrer.PathAndQuery);

            if (Url.IsLocalUrl(ReturnUrl) && !string.IsNullOrEmpty(ReturnUrl))
                ViewBag.ReturnURL = ReturnUrl;
            var model = new LogOnModel();
            return View(model);
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<ActionResult> LogOn(LogOnModel model, string returnUrl)
        {
            var loginSuccess = await PerformLoginActions(model.UserName, model.Password);
            if (loginSuccess.StatusIsSuccessful)
            {
                var roles = loginSuccess.Roles.Split(',');
                if (roles.Any(m=>m.ToUpper()== "COACH"))
                {
                    return RedirectToAction("teams", "TeamManagement", new { area = "Management" });
                }
                // 
                return RedirectToAction("Games", "Home");
            }

            ModelState.Clear();
            ModelState.AddModelError("", "The username or password is incorrect");
            return View(model);
        }

        private async Task<TokenResponse> PerformLoginActions(string email, string password)
        {
            var response = await _loginClient.Login(email, password);
            if (!response.StatusIsSuccessful) return response;
            var options = new AuthenticationProperties
            {
                AllowRefresh = true,
                IsPersistent = true,
                ExpiresUtc = DateTime.UtcNow.AddSeconds(response.Expires_In)
            };
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, email),
                new Claim("AcessToken", $"Bearer {response.Data}"),
                new Claim("FirstName", response.FirstName),
                new Claim("LastName", response.LastName),
                new Claim("Roles", response.Roles)
            };
            var identity = new ClaimsIdentity(claims, "ApplicationCookie");
            Request.GetOwinContext().Authentication.SignIn(options, identity);
            return response;
        }

        protected void AddResponseErrorsToModelState(ApiResponse response)
        {
            var errors = response.ErrorState.ModelState;
            if (errors == null)
                return;

            foreach (var error in errors)
            foreach (var entry in
                from entry in ModelState
                let matchSuffix = string.Concat(".", entry.Key)
                where error.Key.EndsWith(matchSuffix)
                select entry)
                ModelState.AddModelError(entry.Key, error.Value[0]);
        }

        public ActionResult Register()
        {
            var model = new RegisterModel();
            return View(model);
        }

        [HttpPost]
        //  [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            var response = await _loginClient.Register(model);
            if (response.StatusIsSuccessful)
            {
                if (_userSessionBus.Roles.Any(m => m.ToUpper() == "COACH"))
                {
                    return RedirectToAction("teams", "TeamManagement", new { area = "Management" });
                }
                return RedirectToAction("Games", "Home");
            }
                

            AddResponseErrorsToModelState(response);
            return View(model);
        }

        public ActionResult LogOff()
        {
            Request.GetOwinContext().Authentication.SignOut("ApplicationCookie");
            return RedirectToAction("LogOn", "Account");
        }
    }
}