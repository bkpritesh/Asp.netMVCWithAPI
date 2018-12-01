using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace web.Areas.Management.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Management/Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}