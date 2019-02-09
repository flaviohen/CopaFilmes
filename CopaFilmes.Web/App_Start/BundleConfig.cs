using System.Web;
using System.Web.Optimization;

namespace CopaFilmes.Web
{
	public class BundleConfig
	{
		// Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
						"~/Scripts/jquery-{version}.js"));

			// Use a versão em desenvolvimento do Modernizr para desenvolver e aprender com ela. Após isso, quando você estiver
			// pronto para a produção, utilize a ferramenta de build em https://modernizr.com para escolher somente os testes que precisa.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Scripts/modernizr-*"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
					  "~/Scripts/bootstrap.bundle.min.js",
					  "~/Scripts/jquery.easing.min.js",
					  "~/Scripts/jquery.magnific-popup.min.js",
					  "~/Scripts/freelancer.min.js",
					  "~/Scripts/Geral.js"));

			bundles.Add(new StyleBundle("~/Content/css").Include(
					  "~/Content/bootstrap.min.css",
					  "~/Content/Site.css",
					  "~/Content/all.min.css",
					  "~/Content/freelancer.min.css"));
		}
	}
}
