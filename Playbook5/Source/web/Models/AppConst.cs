using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace web.Models
{
    public static class AppConst
    {
        public static string WebApiUrl = GetWebApiUrl;
        private static string GetWebApiUrl => string.IsNullOrEmpty(WebApiUrl) ? ConfigurationManager.AppSettings["WebApiUrl"] : WebApiUrl;
    }
}