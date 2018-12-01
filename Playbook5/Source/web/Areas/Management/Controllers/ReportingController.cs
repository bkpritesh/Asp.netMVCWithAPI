using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using web.Areas.Management.ViewModels;

namespace web.Areas.Management.Controllers
{
    public class ReportingController : Controller
    {
        // GET: Management/Reporting
        [HttpPost]
        public async Task<ActionResult> Team(ReportingViewModel vm)
        {
            ReportingViewModel model = new ReportingViewModel();
            model.TeamId = vm.TeamId;
            model.ReportingModel = await vm.GetTeamReporting(vm.TeamId);
            model.Load();
            return View(model);
        }
        public ActionResult Team()
        {
            ReportingViewModel model = new ReportingViewModel();
            model.Load();
            return View(model);
        }
    }
}