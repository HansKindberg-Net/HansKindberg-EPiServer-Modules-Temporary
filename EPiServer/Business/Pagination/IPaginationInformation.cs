using System;
using System.Collections;
using System.Collections.Generic;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.Pagination
{
	public interface IPaginationInformation
	{
		#region Properties

		IEnumerable<IPage> DisplayedPages { get; }
		Uri FirstPageUrl { get; }
		IEnumerable Items { get; }
		Uri LastPageUrl { get; }
		Uri NextPageGroupUrl { get; }
		Uri NextPageUrl { get; }
		IPage Page { get; }
		IEnumerable<IPage> Pages { get; }
		Uri PreviousPageGroupUrl { get; }
		Uri PreviousPageUrl { get; }

		#endregion
	}

	public interface IPaginationInformation<out T> : IPaginationInformation
	{
		#region Properties

		new IEnumerable<IPage<T>> DisplayedPages { get; }
		new IEnumerable<T> Items { get; }
		new IPage<T> Page { get; }
		new IEnumerable<IPage<T>> Pages { get; }

		#endregion
	}
}