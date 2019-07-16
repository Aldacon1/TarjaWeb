using System.Web;
using System.Web.Optimization;

namespace TarjaAEP
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/Login").Include("~/assets/custom/scripts/pages/Login.js"));
            bundles.Add(new ScriptBundle("~/bundles/Desconsolidado").Include("~/assets/custom/scripts/pages/Desconsolidado.js"));
            bundles.Add(new ScriptBundle("~/bundles/Consolidado").Include("~/assets/custom/scripts/pages/Consolidado.js"));
            bundles.Add(new ScriptBundle("~/bundles/Despacho").Include("~/assets/custom/scripts/pages/Despacho.js"));
            bundles.Add(new ScriptBundle("~/bundles/ClienteLogin").Include("~/assets/custom/scripts/pages/ClienteLogin.js"));
            bundles.Add(new ScriptBundle("~/bundles/Cliente").Include("~/assets/custom/scripts/pages/Cliente.js"));
            bundles.Add(new ScriptBundle("~/bundles/tarjaAEP").Include("~/assets/custom/scripts/pages/tarjaAEP.js"));
            bundles.Add(new ScriptBundle("~/bundles/Bultos").Include("~/assets/custom/scripts/pages/Bultos.js"));
            bundles.Add(new ScriptBundle("~/bundles/ClientesMnt").Include("~/assets/custom/scripts/pages/ClientesMnt.js"));
            bundles.Add(new ScriptBundle("~/bundles/Naves").Include("~/assets/custom/scripts/pages/Naves.js"));
            bundles.Add(new ScriptBundle("~/bundles/Personas").Include("~/assets/custom/scripts/pages/Personas.js"));
            bundles.Add(new ScriptBundle("~/bundles/Terminales").Include("~/assets/custom/scripts/pages/Terminales.js"));
        }
    }
}
