using System;
using System.Collections.Generic;
using EPiServer.Core;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Filters
{
	public class CountFilter : ContentFilter, ICountFilter
	{
		#region Properties

		public virtual int Count { get; set; }

		#endregion

		#region Methods

		public override void Filter(IList<IContent> contents)
		{
			if(contents == null)
				throw new ArgumentNullException("contents");

			for(int i = contents.Count - 1; i >= 0; i--)
			{
				if(i >= this.Count)
					contents.RemoveAt(i);
			}
		}

		public override bool ShouldFilter(IContent content)
		{
			return false;
		}

		#endregion
	}
}