using System.Web.Optimization;

namespace Jobney.Casm.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js-base").Include(
                        "~/Scripts/libs/jquery-{version}.js",
                        "~/Scripts/libs/bootstrap.js",
                        "~/Scripts/libs/select2.js",
                        "~/Scripts/libs/bootstrap-datepicker.js",
                        "~/Scripts/libs/respond.js",
                        "~/Scripts/libs/lodash.js",
                        "~/Scripts/endless.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/fullcalendar").Include(
                        "~/Scripts/libs/fullcalendar.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/libs/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/ng-base").Include(
                        "~/Scripts/libs/angular/angular.js",
                        "~/Scripts/libs/angular/ui-router.js",
                        "~/Scripts/libs/angular/ui-bootstrap-custom-0.9.0.js",
                        "~/Scripts/libs/angular/ui-bootstrap-custom-tpls-0.9.0.js",
                        "~/Scripts/libs/angular/angular-animate.js",
                        "~/Scripts/libs/angular/toaster.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/ng-shared-services")
                .IncludeDirectory("~/Scripts/apps/shared/", "*.js"));

            bundles.Add(new ScriptBundle("~/bundles/ng-manage-app")
                .IncludeDirectory("~/Scripts/apps/manage/","*.js"));

            bundles.Add(new ScriptBundle("~/bundles/ng-tripinfo-app")
                .Include(
                    "~/Scripts/libs/jquery-ui.js",
                    "~/Scripts/libs/angular/sortable.js",
                    "~/Scripts/libs/angular/select2.js",
                    "~/Scripts/libs/angular/ngAutocomplete.js"
                )
                .IncludeDirectory("~/Scripts/apps/tripinfo/", "*.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/libs/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css/base").Include(
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/datepicker3.css",
                      "~/Content/css/select2.css",
                      "~/Content/css/toaster.css",
                      "~/Content/css/select2-bootstrap.css",
                      "~/Content/css/font-awesome.css"
                    ));
            bundles.Add(new StyleBundle("~/Content/css/custom").Include(
                      "~/Content/css/endless.css",
                      "~/Content/css/endless-skin.css",
                      "~/Content/css/site.css"));

            bundles.Add(new StyleBundle("~/Content/css/fullcalendar").Include(
                      "~/Content/css/fullcalendar.css"
                      ));
        }
    }
}
