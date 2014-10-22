using System;
using System.Collections.Generic;
using System.Linq;
using EPiServer.Core;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Filters
{
	public class ContentTypeFilter : ContentFilter, IContentTypeFilter
	{
		#region Fields

		private readonly IEnumerable<int> _contentTypes;

		#endregion

		#region Constructors

		public ContentTypeFilter(IEnumerable<int> contentTypes)
		{
			if(contentTypes == null)
				throw new ArgumentNullException("contentTypes");

			this._contentTypes = contentTypes;
		}

		#endregion

		#region Properties

		public virtual IEnumerable<int> ContentTypes
		{
			get { return this._contentTypes; }
		}

		public virtual bool Exclude { get; set; }

		#endregion

		#region Methods

		public override bool ShouldFilter(IContent content)
		{
			if(content == null)
				throw new ArgumentNullException("content");

			if(this.ContentTypes == null || !this.ContentTypes.Any())
				return false;

			var isInContentTypes = this.ContentTypes.Contains(content.ContentTypeID);

			if(this.Exclude)
				return isInContentTypes;

			return !isInContentTypes;
		}

		#endregion
	}
}