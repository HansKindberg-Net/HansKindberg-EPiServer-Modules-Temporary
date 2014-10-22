using System;
using System.Collections.Generic;
using EPiServer.Core;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Core
{
	public class ContentAreaWrapper : IContentArea
	{
		#region Fields

		private readonly ContentArea _contentArea;

		#endregion

		#region Constructors

		public ContentAreaWrapper(ContentArea contentArea)
		{
			if(contentArea == null)
				throw new ArgumentNullException("contentArea");

			this._contentArea = contentArea;
		}

		#endregion

		#region Properties

		protected internal virtual ContentArea ContentArea
		{
			get { return this._contentArea; }
		}

		public virtual IList<ContentAreaItem> Items
		{
			get { return this.ContentArea.Items; }
		}

		#endregion

		#region Methods

		public static ContentAreaWrapper FromContentArea(ContentArea contentArea)
		{
			return contentArea;
		}

		#endregion

		#region Implicit operator

		public static implicit operator ContentAreaWrapper(ContentArea contentArea)
		{
			return contentArea == null ? null : new ContentAreaWrapper(contentArea);
		}

		#endregion
	}
}