using System.Web;
using System.Web.Optimization;

namespace GentleTraveller
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

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                    "~/lib/src/angular/angular.js",
                    "~/lib/src/angular-route/angular-route.js",
                    "~/lib/src/lodash/lodash.js",
                    "~/lib/src/restangular/restangular.js",
                    "~/lib/src/angular-animate/angular-animate.js",
                    "~/lib/src/angular-aria/angular-aria.js",
                    "~/lib/src/angular-material/angular-material.js",
                    "~/lib/src/angular-material-icons/angular-material-icons.min.js",
                    "~/app/transporterlist/ng-module-transporterlist.js",
                    "~/app/transporterlist/ng-config-transporterlist.js",
                    "~/app/transporterlist/ng-controller-layout.js",
                    "~/app/transporterlist/ng-controller-transporterlist.js"
                    ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/lib/src/ng-table/ng-table.min.css",
                      "~/lib/src/angular-material/angular-material.css",
                      //"~/lib/src/angular-material/angular-material-icons.css",
                      "~/Content/site.css"));
        }
    }
}
