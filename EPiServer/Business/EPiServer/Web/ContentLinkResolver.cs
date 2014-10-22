using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.Web;
using EPiServer.Web.Routing;
using HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Core;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Web
{
	public class ContentLinkResolver : IContentLinkResolver
	{
		#region Fields

		private readonly IAnchorLinks _anchorLinks;
		private readonly IContentLoader _contentLoader;
		private readonly ILanguageBranchRepository _languageBranchRepository;
		private readonly UrlResolver _urlResolver;

		#endregion

		#region Constructors

		public ContentLinkResolver(UrlResolver urlResolver, IContentLoader contentLoader, ILanguageBranchRepository languageBranchRepository, IAnchorLinks anchorLinks)
		{
			if(urlResolver == null)
				throw new ArgumentNullException("urlResolver");

			if(contentLoader == null)
				throw new ArgumentNullException("contentLoader");

			if(languageBranchRepository == null)
				throw new ArgumentNullException("languageBranchRepository");

			if(anchorLinks == null)
				throw new ArgumentNullException("anchorLinks");

			this._anchorLinks = anchorLinks;
			this._contentLoader = contentLoader;
			this._languageBranchRepository = languageBranchRepository;
			this._urlResolver = urlResolver;
		}

		#endregion

		#region Properties

		protected internal virtual IAnchorLinks AnchorLinks
		{
			get { return this._anchorLinks; }
		}

		protected internal virtual IContentLoader ContentLoader
		{
			get { return this._contentLoader; }
		}

		protected internal virtual ILanguageBranchRepository LanguageBranchRepository
		{
			get { return this._languageBranchRepository; }
		}

		protected internal virtual UrlResolver UrlResolver
		{
			get { return this._urlResolver; }
		}

		#endregion

		#region Methods

		public virtual IContent GetContent(string url)
		{
			return this.GetContent(new Uri(url, UriKind.RelativeOrAbsolute));
		}

		public virtual IContent GetContent(Uri url)
		{
			return this.GetContent(new UrlBuilder(url));
		}

		public virtual IContent GetContent(UrlBuilder urlBuilder)
		{
			return this.UrlResolver.Route(urlBuilder);
		}

		public virtual IContent GetContent(string url, ContextMode contextMode)
		{
			return this.GetContent(new Uri(url, UriKind.RelativeOrAbsolute), contextMode);
		}

		public virtual IContent GetContent(Uri url, ContextMode contextMode)
		{
			return this.GetContent(new UrlBuilder(url), contextMode);
		}

		public virtual IContent GetContent(UrlBuilder urlBuilder, ContextMode contextMode)
		{
			return this.UrlResolver.Route(urlBuilder, contextMode);
		}

		[SuppressMessage("Microsoft.Design", "CA1057:StringUriOverloadsCallSystemUriOverloads")]
		[SuppressMessage("Microsoft.Usage", "CA2234:PassSystemUriObjectsInsteadOfStrings")]
		public virtual ContentReference GetContentLink(string url)
		{
			return this.GetContentLink(this.GetContent(url));
		}

		protected internal virtual ContentReference GetContentLink(IContent content)
		{
			if(content == null)
				return null;

			return content.ContentLink;
		}

		public virtual ContentReference GetContentLink(Uri url)
		{
			return this.GetContentLink(this.GetContent(url));
		}

		public virtual ContentReference GetContentLink(UrlBuilder urlBuilder)
		{
			return this.GetContentLink(this.GetContent(urlBuilder));
		}

		[SuppressMessage("Microsoft.Design", "CA1057:StringUriOverloadsCallSystemUriOverloads")]
		[SuppressMessage("Microsoft.Usage", "CA2234:PassSystemUriObjectsInsteadOfStrings")]
		public virtual ContentReference GetContentLink(string url, ContextMode contextMode)
		{
			return this.GetContentLink(this.GetContent(url, contextMode));
		}

		public virtual ContentReference GetContentLink(Uri url, ContextMode contextMode)
		{
			return this.GetContentLink(this.GetContent(url, contextMode));
		}

		public virtual ContentReference GetContentLink(UrlBuilder urlBuilder, ContextMode contextMode)
		{
			return this.GetContentLink(this.GetContent(urlBuilder, contextMode));
		}

		public virtual string GetUrl(ILinkContent content)
		{
			return this.GetUrl(content, null);
		}

		public virtual string GetUrl(ILinkContent content, ContextMode contextMode)
		{
			return this.GetUrl(content, null, contextMode);
		}

		public virtual string GetUrl(ILinkContent content, string culture)
		{
			return this.GetUrl(content, culture, ContextMode.Undefined);
		}

		[SuppressMessage("Microsoft.Usage", "CA2234:PassSystemUriObjectsInsteadOfStrings")]
		public virtual string GetUrl(ILinkContent content, string culture, ContextMode contextMode)
		{
			if(content == null)
				throw new ArgumentNullException("content");

			if(content.LinkType == PageShortcutType.External)
				return content.LinkUrl;

			if(content.LinkType == PageShortcutType.Inactive)
				return this.AnchorLinks.Inactive;

			var contentLink = content.ContentLink;

			if(content.LinkType == PageShortcutType.Shortcut)
				contentLink = content.ShortcutLink;

			if(ContentReference.IsNullOrEmpty(contentLink))
				return this.AnchorLinks.Empty;

			culture = this.LanguageBranchRepository.ListEnabled().Any(languageBranch => languageBranch.LanguageID.Equals(culture, StringComparison.OrdinalIgnoreCase)) ? culture : string.Empty;

			return this.UrlResolver.GetUrl(contentLink, culture, new VirtualPathArguments {ContextMode = contextMode});
		}

		public virtual string GetUrl(ContentReference contentLink)
		{
			return this.GetUrl(contentLink, null);
		}

		public virtual string GetUrl(ContentReference contentLink, ContextMode contextMode)
		{
			return this.GetUrl(contentLink, null, contextMode);
		}

		public virtual string GetUrl(ContentReference contentLink, string culture)
		{
			return this.GetUrl(contentLink, culture, ContextMode.Undefined);
		}

		public virtual string GetUrl(ContentReference contentLink, string culture, ContextMode contextMode)
		{
			ILinkContent linkContent;

			if(this.ContentLoader.TryGet(contentLink, out linkContent))
				return this.GetUrl(linkContent, culture, contextMode);

			return this.UrlResolver.GetUrl(contentLink, culture, new VirtualPathArguments {ContextMode = contextMode});
		}

		#endregion
	}
}