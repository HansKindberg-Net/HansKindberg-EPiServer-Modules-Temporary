using System.Collections.Generic;
using System.Globalization;
using EPiServer.Core;
using EPiServer.Filters;
using HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Sorting;
using HansKindberg.EPiServer.Modules.TestApplication.Business.Sorting;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Filters
{
	public interface ISortFilter : IContentFilter, IComparer<IContent>
	{
		#region Properties

		CompareInfo CompareInformation { get; set; }
		SortDirection Direction { get; set; }
		SortOrder Order { get; set; }

		#endregion

		#region Methods

		void Sort(IList<IContent> contents);

		#endregion
	}
}