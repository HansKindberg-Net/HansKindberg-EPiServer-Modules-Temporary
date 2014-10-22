using System;
using System.Collections.Generic;
using HansKindberg.EPiServer.Modules.TestApplication.Business.Collections;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.Pagination
{
	public interface IPage
	{
		#region Properties

		bool Current { get; }
		bool First { get; }
		bool FirstInGroup { get; }
		int Index { get; }
		IEnumerable<IListItem> Items { get; }
		bool Last { get; }
		bool LastInGroup { get; }
		Uri Url { get; }

		#endregion
	}

	public interface IPage<out T> : IPage
	{
		#region Properties

		new IEnumerable<IListItem<T>> Items { get; }

		#endregion
	}
}