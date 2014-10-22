using System.Web.Optimization;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.Configuration
{
	public class BundleConfiguration : IApplicationConfiguration
	{
		#region Methods

		public virtual void Configure()
		{
			this.RegisterBundles(BundleTable.Bundles);
		}

		// For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
		protected internal virtual void RegisterBundles(BundleCollection bundles)
		{
			bundles = bundles;

			//bundles.Add(new ScriptBundle("~/bundles/js").Include(
			//	"~/Static/js/jquery.js", //jquery.js can be removed and linked from CDN instead, we use a local one for demo purposes without internet connectionzz
			//	"~/Static/js/bootstrap.js"));

			//bundles.Add(new StyleBundle("~/bundles/css")
			//	.Include("~/Static/css/bootstrap.css", new CssRewriteUrlTransform())
			//	.Include("~/Static/css/bootstrap-responsive.css")
			//	.Include("~/Static/css/media.css")
			//	.Include("~/Static/css/style.css", new CssRewriteUrlTransform())
			//	.Include("~/Static/css/editmode.css"));
		}

		#endregion
	}
}