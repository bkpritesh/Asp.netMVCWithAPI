using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Intro", action = "Index", id = UrlParameter.Optional },
            //    namespaces: new[] { "web.Areas.Intro.Controllers" }
            //).DataTokens = new RouteValueDictionary(new { area = "Intro" });

            routes.MapRoute(
                name: "Default1",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            ).DataTokens["area"] = "default";

            routes.MapRoute(
            "TeamPlayRoute",                                              // Route name
            "{controller}/{action}/{teamId}/{playId}",                           // URL with parameters
            new { controller = "Home", action = "Index", teamId = UrlParameter.Optional, playId = UrlParameter.Optional }  // Parameter defaults
        ).DataTokens["area"] = "default";
        }
    }
}
