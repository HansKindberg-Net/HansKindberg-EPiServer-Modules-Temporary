using System;
using System.Collections.Generic;
using System.Linq;
using HansKindberg.EPiServer.Modules.TestApplication.Business.Collections;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.Pagination
{
	public class Page<T> : IPage<T>
	{
		#region Fields

		private IEnumerable<IListItem<T>> _items;

		#endregion

		#region Properties

		public virtual bool Current { get; set; }
		public virtual bool First { get; set; }
		public virtual bool FirstInGroup { get; set; }
		public virtual int Index { get; set; }

		IEnumerable<IListItem> IPage.Items
		{
			get { return this.Items; }
		}

		public virtual IEnumerable<IListItem<T>> Items
		{
			get { return this._items ?? (this._items = Enumerable.Empty<IListItem<T>>()); }
			set { this._items = value; }
		}

		public virtual bool Last { get; set; }
		public virtual bool LastInGroup { get; set; }
		public virtual Uri Url { get; set; }

		#endregion
	}
}