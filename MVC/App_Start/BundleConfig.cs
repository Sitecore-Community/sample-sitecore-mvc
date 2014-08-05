using System.Web;
using System.Web.Optimization;

namespace MVC.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js/jquery").Include(
                        "~/Content/scripts/lib/jquery/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/js/jqueryui").Include(
                        "~/Content/scripts/lib/jquery/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/js/jqueryval").Include(
                        "~/Content/scripts/lib/jquery/jquery.unobtrusive*",
                        "~/Content/scripts/lib/jquery/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/js/site").Include(
                "~/Content/scripts/lib/jquery/jquery-{version}.js",
                "~/Content/scripts/lib/jquery/jquery-ui-{version}.js",
                "~/Content/scripts/lib/jquery/jquery.unobtrusive*",
                "~/Content/scripts/lib/jquery/jquery.validate*",
                "~/Content/scripts/lib/bootstrap/bootstrap*",
                "~/Content/scripts/custom/site.js"));

            bundles.Add(new StyleBundle("~/bundles/css/site").Include(
                "~/Content/css/site.css"));

            bundles.Add(new StyleBundle("~/bundles/themes/base/css").Include(
                        "~/Content/css/themes/base/jquery.ui.core.css",
                        "~/Content/css/themes/base/jquery.ui.resizable.css",
                        "~/Content/css/themes/base/jquery.ui.selectable.css",
                        "~/Content/css/themes/base/jquery.ui.accordion.css",
                        "~/Content/css/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/css/themes/base/jquery.ui.button.css",
                        "~/Content/css/themes/base/jquery.ui.dialog.css",
                        "~/Content/css/themes/base/jquery.ui.slider.css",
                        "~/Content/css/themes/base/jquery.ui.tabs.css",
                        "~/Content/css/themes/base/jquery.ui.datepicker.css",
                        "~/Content/css/themes/base/jquery.ui.progressbar.css",
                        "~/Content/css/themes/base/jquery.ui.theme.css"));
        }
    }
}