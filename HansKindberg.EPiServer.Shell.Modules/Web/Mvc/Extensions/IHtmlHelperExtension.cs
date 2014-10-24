using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Web;
using System.Web.Mvc;
using EPiServer.Framework.Web.Resources;

namespace HansKindberg.EPiServer.Shell.Modules.Web.Mvc.Extensions
{
	public interface IHtmlHelperExtension
	{
		#region Methods

		[SuppressMessage("Microsoft.Naming", "CA1719:ParameterNamesShouldNotMatchMemberNames", MessageId = "1#")]
		IHtmlString ClientResource(HtmlHelper htmlHelper, ClientResource clientResource);

		string ClientResourceHtmlTag(HtmlHelper htmlHelper, ClientResource clientResource);

		[SuppressMessage("Microsoft.Naming", "CA1719:ParameterNamesShouldNotMatchMemberNames", MessageId = "1#")]
		IHtmlString ClientResources(HtmlHelper htmlHelper, IEnumerable<ClientResource> clientResources);

		#endregion
	}
}