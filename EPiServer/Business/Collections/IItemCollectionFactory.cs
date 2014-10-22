using System;
using System.Collections.Generic;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.Collections
{
	public interface IItemCollectionFactory
	{
		#region Methods

		IEnumerable<IListItem<T>> CreateListItems<T>(IEnumerable<T> items);
		IEnumerable<IListItem<T>> CreateListItems<T>(IEnumerable<T> items, Func<T, bool> isSelectedDelegate);

		#endregion
	}
}