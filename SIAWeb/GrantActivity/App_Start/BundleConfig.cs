﻿using System.Web;
using System.Web.Optimization;

namespace GrantActivity
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
            //bundles.Add(new ScriptBundle("~/bundles/googlejquery", "https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js").Include(
            //           "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/moment","https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.12.0/moment.js"));

            //bundles.Add(new ScriptBundle("~/bundles/fullcalendar", "https://cdnjs.cloudflare.com/ajax/libs/fullcalendar/3.6.1/fullcalendar.min.js").Include(
            //           "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/datetimepicker", "https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.47/js/bootstrap-datetimepicker.min.js").Include(
            //          "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jquerys").Include(
            //            "~/Scripts/jquery-1.9.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js"));

            

            //bundles.Add(new ScriptBundle("~/bundles/fullcalendarjs").Include(
            //          "~/Scripts/fullcalendar.js"));

            //bundles.Add(new ScriptBundle("~/bundles/datepick").Include(
            //            "~/Scripts/bootstrap-datetimepicker.min.js"));



            //bundles.Add(new ScriptBundle("~/bundles/jquerymask").Include(
            //    "~/Scripts/jquery.maskedinput*",
            //    "~/Scripts/maskedinput-binder.js"));

            bundles.Add(new StyleBundle("~/Content/font-awesome", "http://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"));


            bundles.Add(new StyleBundle("~/Content/bootstrap").Include("~/Content/Slate.css"));
            //bundles.Add(new StyleBundle("~/Content/bootstrap").Include("~/Content/bootstrap.css"));
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/fullcalendar").Include("~/Content/fullcalendar.css"));
            bundles.Add(new StyleBundle("~/Content/fullcalendarprint", "https://cdnjs.cloudflare.com/ajax/libs/fullcalendar/3.6.1/fullcalendar.print.css"));

            //bundles.Add(new StyleBundle("~/Content/fullcalendarprint").Include("~/Content/fullcalendar.print.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));



            BundleTable.EnableOptimizations = true;
            bundles.UseCdn = true;

        }
    }
   
}