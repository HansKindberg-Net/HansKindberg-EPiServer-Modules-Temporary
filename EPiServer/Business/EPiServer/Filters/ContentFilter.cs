using System;
using System.Collections.Generic;
using EPiServer.Core;
using EPiServer.Filters;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Filters
{
	public abstract class ContentFilter : IContentFilter
	{
		#region Methods

		public virtual void Filter(IList<IContent> contents)
		{
			if(contents == null)
				throw new ArgumentNullException("contents");

			for(int i = contents.Count - 1; i >= 0; i--)
			{
				if(this.ShouldFilter(contents[i]))
				{
					contents.RemoveAt(i);
				}
			}
		}

		public abstract bool ShouldFilter(IContent content);

		#endregion

		#region Eventhandlers

		public virtual void Filter(object sender, ContentFilterEventArgs e)
		{
			if(e == null)
				throw new ArgumentNullException("e");

			this.Filter(e.Contents);
		}

		#endregion
	}
}