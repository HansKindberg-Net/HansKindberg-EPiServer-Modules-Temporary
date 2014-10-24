using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Web;
using System.Web.Mvc;
using EPiServer.Framework.Web.Resources;

namespace HansKindberg.EPiServer.Shell.Modules.Web.Mvc.Extensions
{
	public static class HtmlHelperExtension
	{
		#region Fields

		private static volatile IHtmlHelperExtension _instance;
		private static readonly object _lockObject = new object();

		#endregion

		#region Properties

		public static IHtmlHelperExtension Instance
		{
			get
			{
				if(_instance == null)
				{
					lock(_lockObject)
					{
						if(_instance == null)
							_instance = new DefaultHtmlHelperExtension();
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

		[SuppressMessage("Microsoft.Naming", "CA1719:ParameterNamesShouldNotMatchMemberNames", MessageId = "1#")]
		public static IHtmlString ClientResource(this HtmlHelper htmlHelper, ClientResource clientResource)
		{
			return Instance.ClientResource(htmlHelper, clientResource);
		}

		public static string ClientResourceHtmlTag(this HtmlHelper htmlHelper, ClientResource clientResource)
		{
			return Instance.ClientResourceHtmlTag(htmlHelper, clientResource);
		}

		[SuppressMessage("Microsoft.Naming", "CA1719:ParameterNamesShouldNotMatchMemberNames", MessageId = "1#")]
		public static IHtmlString ClientResources(this HtmlHelper htmlHelper, IEnumerable<ClientResource> clientResources)
		{
			return Instance.ClientResources(htmlHelper, clientResources);
		}

		#endregion
	}
}