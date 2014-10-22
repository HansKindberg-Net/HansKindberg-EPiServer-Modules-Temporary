using System;
using System.Diagnostics.CodeAnalysis;
using EPiServer;
using EPiServer.Core;
using EPiServer.Web;
using HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Core;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Web
{
	public interface IContentLinkResolver
	{
		#region Methods

		IContent GetContent(string url);
		IContent GetContent(Uri url);
		IContent GetContent(UrlBuilder urlBuilder);
		IContent GetContent(string url, ContextMode contextMode);
		IContent GetContent(Uri url, ContextMode contextMode);
		IContent GetContent(UrlBuilder urlBuilder, ContextMode contextMode);
		ContentReference GetContentLink(string url);
		ContentReference GetContentLink(Uri url);
		ContentReference GetContentLink(UrlBuilder urlBuilder);
		ContentReference GetContentLink(string url, ContextMode contextMode);
		ContentReference GetContentLink(Uri url, ContextMode contextMode);
		ContentReference GetContentLink(UrlBuilder urlBuilder, ContextMode contextMode);

		[SuppressMessage("Microsoft.Design", "CA1055:UriReturnValuesShouldNotBeStrings")]
		string GetUrl(ILinkContent content);

		[SuppressMessage("Microsoft.Design", "CA1055:UriReturnValuesShouldNotBeStrings")]
		string GetUrl(ILinkContent content, ContextMode contextMode);

		[SuppressMessage("Microsoft.Design", "CA1055:UriReturnValuesShouldNotBeStrings")]
		string GetUrl(ILinkContent content, string culture);

		[SuppressMessage("Microsoft.Design", "CA1055:UriReturnValuesShouldNotBeStrings")]
		string GetUrl(ILinkContent content, string culture, ContextMode contextMode);

		[SuppressMessage("Microsoft.Design", "CA1055:UriReturnValuesShouldNotBeStrings")]
		string GetUrl(ContentReference contentLink);

		[SuppressMessage("Microsoft.Design", "CA1055:UriReturnValuesShouldNotBeStrings")]
		string GetUrl(ContentReference contentLink, ContextMode contextMode);

		[SuppressMessage("Microsoft.Design", "CA1055:UriReturnValuesShouldNotBeStrings")]
		string GetUrl(ContentReference contentLink, string culture);

		[SuppressMessage("Microsoft.Design", "CA1055:UriReturnValuesShouldNotBeStrings")]
		string GetUrl(ContentReference contentLink, string culture, ContextMode contextMode);

		#endregion
	}
}