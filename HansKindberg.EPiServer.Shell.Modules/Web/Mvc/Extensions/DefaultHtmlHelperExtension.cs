using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer.Framework.Web.Resources;

namespace HansKindberg.EPiServer.Shell.Modules.Web.Mvc.Extensions
{
	public class DefaultHtmlHelperExtension : IHtmlHelperExtension
	{
		#region Methods

		public virtual IHtmlString ClientResource(HtmlHelper htmlHelper, ClientResource clientResource)
		{
			return new HtmlString(this.ClientResourceHtmlTag(htmlHelper, clientResource));
		}

		public virtual string ClientResourceHtmlTag(HtmlHelper htmlHelper, ClientResource clientResource)
		{
			if(htmlHelper == null)
				throw new ArgumentNullException("htmlHelper");

			if(clientResource == null)
				throw new ArgumentNullException("clientResource");

			if(clientResource.IsStatic)
			{
				switch(clientResource.ResourceType)
				{
					case ClientResourceType.Script:
						return string.Format(CultureInfo.InvariantCulture, "<script src=\"{0}\"></script>", new object[] {clientResource.Path});

					case ClientResourceType.Style:
						return string.Format(CultureInfo.InvariantCulture, "<link href=\"{0}\" rel=\"stylesheet\" />", new object[] {clientResource.Path});
				}
			}
			else if(!string.IsNullOrWhiteSpace(clientResource.InlineContent))
			{
				switch(clientResource.ResourceType)
				{
					case ClientResourceType.Script:
						return string.Format(CultureInfo.InvariantCulture, "<script>{1}{0}{1}</script>", new object[] {clientResource.InlineContent, Environment.NewLine});

					case ClientResourceType.Style:
						return string.Format(CultureInfo.InvariantCulture, "<style>{1}{0}{1}</style>", new object[] {clientResource.InlineContent, Environment.NewLine});

					case ClientResourceType.Html:
						return string.Format(CultureInfo.InvariantCulture, "{1}{0}{1}", new object[] {clientResource.InlineContent, Environment.NewLine});
				}
			}

			return string.Empty;
		}

		public virtual IHtmlString ClientResources(HtmlHelper htmlHelper, IEnumerable<ClientResource> clientResources)
		{
			if(htmlHelper == null)
				throw new ArgumentNullException("htmlHelper");

			if(clientResources == null)
				throw new ArgumentNullException("clientResources");

			var clientResourceHtmlTags = clientResources.Select(clientResource => this.ClientResourceHtmlTag(htmlHelper, clientResource)).ToArray();

			return new HtmlString(string.Join(Environment.NewLine, clientResourceHtmlTags));
		}

		#endregion
	}
}