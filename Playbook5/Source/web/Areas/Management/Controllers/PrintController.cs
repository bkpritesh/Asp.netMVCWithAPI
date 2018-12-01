using System.Threading.Tasks;
using System.Web.Mvc;
using web.Areas.Management.ViewModels;

namespace web.Areas.Management.Controllers
{
    public class PrintController : Controller
    {
        // GET: Management/Print
        public async Task<ActionResult> TeamReport(string id)
        {
            ReportingViewModel model = new ReportingViewModel();
            model.ReportingModel = await model.GetTeamReporting(id);
            return View(model);
        }
    }
}