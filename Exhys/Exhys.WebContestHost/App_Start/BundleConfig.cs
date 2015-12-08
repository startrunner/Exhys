﻿using System.Web;
using System.Web.Optimization;

namespace Exhys.WebContestHost
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles (BundleCollection bundles)
        {
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
						"~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-ui").Include(
                        "~/Scripts/jquery-ui.min.js",
                        "~/Scripts/selectableScroll.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
						"~/Scripts/jquery.validate*"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
					  "~/Scripts/bootstrap.js",
					  "~/Scripts/respond.js"));

			//bundles.Add(new StyleBundle("~/Content/css").Include(
			//		  "~/Content/bootstrap.css",
			//		  "~/Content/site.css"));

			bundles.Add(new StyleBundle("~/Content/custom-css").Include(
					  "~/Content/custom-style.css",
					  "~/Content/shit.css",
                      "~/Content/jquery-ui.min.css",
                      "~/Content/jquery-ui.structure.min.css"));            

        }
    }
}
