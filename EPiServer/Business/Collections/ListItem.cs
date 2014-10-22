using System;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.Collections
{
	public class ListItem : CollectionItem, IListItem
	{
		#region Fields

		private int _index;

		#endregion

		#region Properties

		public virtual bool First
		{
			get { return this.Index == 0; }
		}

		public virtual int Index
		{
			get { return this._index; }
			set
			{
				if(value < 0)
					throw new ArgumentOutOfRangeException("value", value, "The value can not be less than zero.");

				this._index = value;
			}
		}

		public virtual bool Last { get; set; }

		#endregion
	}

	public class ListItem<T> : ListItem, IListItem<T>
	{
		#region Properties

		public new T Value
		{
			get { return (T) base.Value; }
			set { base.Value = value; }
		}

		#endregion
	}
}