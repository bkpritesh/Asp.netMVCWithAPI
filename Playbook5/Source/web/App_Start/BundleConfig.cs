using System.Web;
using System.Web.Optimization;

namespace web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap-datetimepicker.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/Allcss").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/css/normalize.css",
                      "~/Content/css/webflow.css",
                      "~/Content/css/playbook-five-account-admin.webflow.css",
                      "~/Content/css/datetimepicker.css",
                       "~/Content/css/datepicker.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/Content/Allscript").Include(
                  "~/Content/scripts/jquery-2.1.1.js",
                   "~/Content/scripts/jquery.validate.js",
                  "~/Content/scripts/jquery.validate.unobtrusive.js",
                  "~/Content/scripts/modernizr.js",
                  "~/Content/scripts/webflow.js",
                  "~/Content/scripts/bootstrap.js",
                  "~/Content/scripts/bootstrap-datepicker.js",
                  "~/Content/scripts/moment.js",
                  "~/Content/scripts/fullcalendar.js",
                  "~/Content/scripts/gcal.js",
                  "~/Content/scripts/spin.js",
                  "~/Content/JS/Teams/teamedit.js",
                  "~/Content/JS/Plays/playedit.js",
                  "~/Content/JS/TeamNotes/teamnoteedit.js",
                   "~/Content/JS/install/install.js"
                  ));
            //  BundleTable.EnableOptimizations = true;
        }
    }
}
