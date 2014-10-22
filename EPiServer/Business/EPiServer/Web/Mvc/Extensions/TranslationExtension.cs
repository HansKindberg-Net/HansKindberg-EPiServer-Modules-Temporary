using System.Diagnostics.CodeAnalysis;
using System.Web.Mvc;
using EPiServer.Framework.Localization;
using EPiServer.ServiceLocation;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Web.Mvc.Extensions
{
	public static class TranslationExtension
	{
		#region Fields

		private static volatile ITranslationExtension _instance;
		private static readonly object _lockObject = new object();

		#endregion

		#region Properties

		public static ITranslationExtension Instance
		{
			get
			{
				if(_instance == null)
				{
					lock(_lockObject)
					{
						if(_instance == null)
							_instance = ServiceLocator.Current.GetInstance<ITranslationExtension>();
					}
				}

				return _instance;
			}
			set
			{
				if(Equals(_instance, value))
					return;

				lock(_lockObject)
				{
					_instance = value;
				}
			}
		}

		#endregion

		#region Methods

		[SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "htmlHelper")]
		public static string Translate(this HtmlHelper htmlHelper, string key, IViewDataContainer view)
		{
			return Instance.Translate(key, view);
		}

		[SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "htmlHelper")]
		public static string Translate(this HtmlHelper htmlHelper, string key, IViewDataContainer view, string fallback)
		{
			return Instance.Translate(key, view, fallback);
		}

		[SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "htmlHelper")]
		public static string Translate(this HtmlHelper htmlHelper, string key, IViewDataContainer view, FallbackBehaviors fallbackBehaviors)
		{
			return Instance.Translate(key, view, fallbackBehaviors);
		}

		#endregion
	}
}