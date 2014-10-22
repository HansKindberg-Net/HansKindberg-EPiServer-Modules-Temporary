using System;
using System.Collections.Generic;
using System.Linq;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.Collections
{
	public class ItemCollectionFactory : IItemCollectionFactory
	{
		#region Methods

		public virtual IEnumerable<IListItem<T>> CreateListItems<T>(IEnumerable<T> items)
		{
			return this.CreateListItems(items, item => false);
		}

		public virtual IEnumerable<IListItem<T>> CreateListItems<T>(IEnumerable<T> items, Func<T, bool> isSelectedDelegate)
		{
			if(items == null)
				throw new ArgumentNullException("items");

			if(isSelectedDelegate == null)
				throw new ArgumentNullException("isSelectedDelegate");

			var listItems = new List<IListItem<T>>();

			// ReSharper disable PossibleMultipleEnumeration
			for(int i = 0; i < items.Count(); i++)
			{
				var item = items.ElementAt(i);

				var listItem = new ListItem<T>
				{
					Index = i,
					Selected = isSelectedDelegate(item),
					Value = item,
				};

				if(i == items.Count() - 1)
					listItem.Last = true;

				listItems.Add(listItem);
			}
			// ReSharper restore PossibleMultipleEnumeration

			return listItems.ToArray();
		}

		#endregion
	}
}