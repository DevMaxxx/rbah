using System.Web.Optimization;

namespace rbah
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new Bundle("~/css", "~/Content/Site.css"));
        }
    }
}
