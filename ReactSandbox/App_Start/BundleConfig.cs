using System.Web.Optimization;
using System.Web.Optimization.React;

namespace ReactSandbox.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/styles").Include(
                "~/node_modules/bootstrap/dist/css/bootstrap.css"));

            bundles.Add(new ScriptBundle("~/bundles/third-party").Include(
                       "~/Scripts/showdown.js"));

            bundles.Add(new BabelBundle("~/bundles/react")
                .Include(
                    "~/node_modules/react/dist/react.js",
                    "~/node_modules/react-dom/dist/react-dom.js")
                .IncludeDirectory(
                    "~/Scripts/JSX", "*.jsx", true));
        }
    }
}