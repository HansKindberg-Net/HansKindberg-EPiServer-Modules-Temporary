using System.Web.Mvc;
using EPiServer.Framework.Localization;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Web.Mvc.Extensions
{
	public interface ITranslationExtension
	{
		#region Methods

		string Translate(string key, IViewDataContainer view);
		string Translate(string key, IViewDataContainer view, string fallback);
		string Translate(string key, IViewDataContainer view, FallbackBehaviors fallbackBehaviors);

		#endregion
	}
}