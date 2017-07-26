using System.Web;
using System.Web.Optimization;

namespace PhotographerPerformance
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                 "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts/angular.js",
                "~/Scripts/angular-mocks.js",
                "~/Scripts/angular-route.js"));

            bundles.Add(new ScriptBundle("~/bundles/angularPlugins").Include(
                "~/Scripts/ng-file-upload.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/Scripts/app/app.module.js",
                "~/Scripts/app/data.service.js",
                "~/Scripts/app/Photo/photo.controller.js",
                "~/Scripts/app/Photo/photo.service.js",
                "~/Scripts/app/Photographer/photographer.controller.js",
                "~/Scripts/app/Photographer/photographer.service.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/Site.css"));
        }
    }
}
