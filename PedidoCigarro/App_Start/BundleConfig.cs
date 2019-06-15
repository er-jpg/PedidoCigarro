using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace PedidoCigarro
{
    public class BundleConfig
    {
        public static void RegisterBundles (BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/bootstrap-datepicker.js",
                "~/Scripts/locales/bootstrap-datepicker.pt-BR.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery-masked").Include("~/Scripts/jquery.maskedinput.js"));
            bundles.Add(new ScriptBundle("~/bundles/popper").Include("~/Scripts/popper.js"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-datepicker.ss"));
            BundleTable.EnableOptimizations = true;
        }
    }
}