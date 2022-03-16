using System.Web;
using System.Web.Optimization;

namespace DLWebsiteWithAuth
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                                   "~/Scripts/jquery.min.js"));


            bundles.Add(new ScriptBundle("~/bundles/jqueryunobtrisive").Include(
                "~/Scripts/jquery.unobtrusive-ajax.min.js",
                "~/Scripts/jquery.validate.unobtrusive.min.js",
                "~/Scripts/jquery.validate.min.js"

                ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-2.6.2.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/site.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryunobtrisive").Include(
                "~/Scripts/jquery.validate.min.js",
                "~/Scripts/jquery.unobtrusive-ajax.min.js",
                "~/Scripts/jquery.validate.unobtrusive.min.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/angularjs").Include(
                "~/Scripts/angular.min.js",
                "~/Scripts/site.min.js",
                "~/Scripts/Custom.min.js",
                "~/Scripts/site-angular.js"));
        }
    }
}
