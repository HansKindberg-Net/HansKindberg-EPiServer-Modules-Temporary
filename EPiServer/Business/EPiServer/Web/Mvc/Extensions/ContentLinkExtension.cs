using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Web;
using System.Web.Mvc;
using EPiServer.ServiceLocation;
using HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Core;
using HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Web.Html;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Web.Mvc.Extensions
{
	public static class ContentLinkExtension
	{
		#region Fields

		private static volatile IContentHtmlLinkFactory _contentHtmlLinkFactory;
		private static readonly object _lockObject = new object();

		#endregion

		#region Properties

		public static IContentHtmlLinkFactory ContentHtmlLinkFactory
		{
			get
			{
				if(_contentHtmlLinkFactory == null)
				{
					lock(_lockObject)
					{
						if(_contentHtmlLinkFactory == null)
							_contentHtmlLinkFactory = ServiceLocator.Current.GetInstance<IContentHtmlLinkFactory>();
					}
				}

				return _contentHtmlLinkFactory;
			}
			set
			{
				if(Equals(_contentHtmlLinkFactory, value))
					return;

				lock(_lockObject)
				{
					_contentHtmlLinkFactory = value;
				}
			}
		}

		#endregion

		#region Methods

		[SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "htmlHelper")]
		public static IHtmlString CreateContentLink(this HtmlHelper htmlHelper, ILinkContent content)
		{
			return ContentHtmlLinkFactory.CreateContentLink(content);
		}

		[SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "htmlHelper")]
		public static IHtmlString CreateContentLink(this HtmlHelper htmlHelper, ILinkContent content, string text)
		{
			return ContentHtmlLinkFactory.CreateContentLink(content, text);
		}

		[SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "htmlHelper")]
		public static IHtmlString CreateContentLink(this HtmlHelper htmlHelper, ILinkContent content, IDictionary<string, object> htmlAttributes)
		{
			return ContentHtmlLinkFactory.CreateContentLink(content, htmlAttributes);
		}

		[SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "htmlHelper")]
		public static IHtmlString CreateContentLink(this HtmlHelper htmlHelper, ILinkContent content, string text, IDictionary<string, object> htmlAttributes)
		{
			return ContentHtmlLinkFactory.CreateContentLink(content, text, htmlAttributes);
		}

		[SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "htmlHelper")]
		public static IHtmlString CreateContentLink(this HtmlHelper htmlHelper, ILinkContent content, string text, IDictionary<string, object> htmlAttributes, string outerTagName)
		{
			return ContentHtmlLinkFactory.CreateContentLink(content, text, htmlAttributes, outerTagName);
		}

		[SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "htmlHelper")]
		public static IHtmlString CreateContentLink(this HtmlHelper htmlHelper, ILinkContent content, string text, IDictionary<string, object> htmlAttributes, string outerTagName, IDictionary<string, object> outerHtmlAttributes)
		{
			return ContentHtmlLinkFactory.CreateContentLink(content, text, htmlAttributes, outerTagName, outerHtmlAttributes);
		}

		#endregion
	}
}