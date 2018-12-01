using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System.Web.Mvc;
using web;
using web.Areas.Management.Models;

[assembly: OwinStartup(typeof(Startup))]
namespace web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ModelBinderProviders.BinderProviders.Insert(0, new ModelBinderProvider());
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Account/LogOn"),

            });
            //ModelBinders.Binders.Add(typeof(Areas.Management.ViewModels.TeamViewModel), new Models.CustomModelBinder1<Areas.Management.ViewModels.TeamViewModel>());
        }
    }
}
