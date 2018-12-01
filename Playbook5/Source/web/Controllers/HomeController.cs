using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using web.Areas.Management.ViewModels;

namespace web.Controllers
{
    
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Games()
        {
            return View();
        }
        public ActionResult SportsMenu()
        {
            return View();
        }
    }
}