using System.Collections.Generic;
using System.Web;
using HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Core;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Web.Html
{
	public interface IContentHtmlLinkFactory
	{
		#region Methods

		IHtmlString CreateContentLink(ILinkContent content);
		IHtmlString CreateContentLink(ILinkContent content, string text);
		IHtmlString CreateContentLink(ILinkContent content, IDictionary<string, object> htmlAttributes);
		IHtmlString CreateContentLink(ILinkContent content, string text, IDictionary<string, object> htmlAttributes);
		IHtmlString CreateContentLink(ILinkContent content, string text, IDictionary<string, object> htmlAttributes, string outerTagName);
		IHtmlString CreateContentLink(ILinkContent content, string text, IDictionary<string, object> htmlAttributes, string outerTagName, IDictionary<string, object> outerHtmlAttributes);

		#endregion
	}
}