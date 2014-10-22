using System;
using System.Collections.Generic;
using System.Linq;
using EPiServer.Core;
using EPiServer.Filters;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Filters.Extensions
{
	public static class ContentFilterExtension
	{
		#region Methods

		public static IContent Filter(this IContentFilter contentFilter, IContent content)
		{
			if(contentFilter == null)
				throw new ArgumentNullException("contentFilter");

			if(content == null)
				return null;

			IList<IContent> contentList = new List<IContent>(new[] {content});

			contentFilter.Filter(contentList);

			return contentList.Any() ? content : null;
		}

		#endregion
	}
}