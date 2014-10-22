using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Core;
using HansKindberg.EPiServer.Modules.TestApplication.Business.Web;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Web.Html
{
	public class ContentHtmlLinkFactory : IContentHtmlLinkFactory
	{
		#region Fields

		private readonly IContentLinkResolver _contentLinkResolver;
		private readonly IHttpEncoder _httpEncoder;

		#endregion

		#region Constructors

		public ContentHtmlLinkFactory(IContentLinkResolver contentLinkResolver, IHttpEncoder httpEncoder)
		{
			if(contentLinkResolver == null)
				throw new ArgumentNullException("contentLinkResolver");

			if(httpEncoder == null)
				throw new ArgumentNullException("httpEncoder");

			this._contentLinkResolver = contentLinkResolver;
			this._httpEncoder = httpEncoder;
		}

		#endregion

		#region Properties

		protected internal virtual IContentLinkResolver ContentLinkResolver
		{
			get { return this._contentLinkResolver; }
		}

		protected internal virtual IHttpEncoder HttpEncoder
		{
			get { return this._httpEncoder; }
		}

		#endregion

		#region Methods

		public virtual IHtmlString CreateContentLink(ILinkContent content)
		{
			return this.CreateContentLink(content, content != null ? content.Name : null);
		}

		public virtual IHtmlString CreateContentLink(ILinkContent content, string text)
		{
			return this.CreateContentLink(content, text, null);
		}

		public virtual IHtmlString CreateContentLink(ILinkContent content, IDictionary<string, object> htmlAttributes)
		{
			return this.CreateContentLink(content, null, htmlAttributes);
		}

		public virtual IHtmlString CreateContentLink(ILinkContent content, string text, IDictionary<string, object> htmlAttributes)
		{
			return this.CreateContentLink(content, text, htmlAttributes, null);
		}

		public virtual IHtmlString CreateContentLink(ILinkContent content, string text, IDictionary<string, object> htmlAttributes, string outerTagName)
		{
			return this.CreateContentLink(content, text, htmlAttributes, outerTagName, null);
		}

		public virtual IHtmlString CreateContentLink(ILinkContent content, string text, IDictionary<string, object> htmlAttributes, string outerTagName, IDictionary<string, object> outerHtmlAttributes)
		{
			if(content == null)
				throw new ArgumentNullException("content");

			if(text == null)
				throw new ArgumentNullException("text");

			var contentLinkTagBuilder = new TagBuilder("a")
			{
				InnerHtml = this.HttpEncoder.HtmlEncode(text)
			};

			contentLinkTagBuilder.MergeAttribute("href", this.ContentLinkResolver.GetUrl(content));

			if(!string.IsNullOrEmpty(content.TargetFrameName))
				contentLinkTagBuilder.MergeAttribute("target", content.TargetFrameName);

			if(htmlAttributes != null)
				contentLinkTagBuilder.MergeAttributes(htmlAttributes);

			var contentLinkTagBuilderString = contentLinkTagBuilder.ToString(TagRenderMode.Normal);

			if(string.IsNullOrEmpty(outerTagName))
				return new HtmlString(contentLinkTagBuilderString);

			var outerTagBuilder = new TagBuilder(outerTagName)
			{
				InnerHtml = contentLinkTagBuilderString
			};

			if(outerHtmlAttributes != null)
				outerTagBuilder.MergeAttributes(outerHtmlAttributes);

			return new HtmlString(outerTagBuilder.ToString(TagRenderMode.Normal));
		}

		#endregion
	}
}