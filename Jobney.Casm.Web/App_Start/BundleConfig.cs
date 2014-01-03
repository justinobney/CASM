﻿using System.Web.Optimization;

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
                        "~/Scripts/libs/respond.js",
                        "~/Scripts/endless.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/fullcalendar").Include(
                        "~/Scripts/libs/fullcalendar.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/libs/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/libs/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css/base").Include(
                      "~/Content/css/bootstrap.css",
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