using System;
using System.Collections.Generic;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.Pagination
{
	public interface IPaginationFactory
	{
		#region Properties

		string PageIndexKey { get; set; }

		#endregion

		#region Methods

		IPaginationInformation<T> Create<T>(IEnumerable<T> items, IPaginationSettings settings, Uri url, Func<T, bool> isSelectedDelegate);

		#endregion
	}
}