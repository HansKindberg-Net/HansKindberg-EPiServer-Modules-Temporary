using System.Collections.Generic;
using EPiServer.Filters;
using HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Core;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Filters
{
	public interface ICategoryFilter : IContentFilter
	{
		#region Properties

		IEnumerable<int> Categories { get; }
		CategoryComparison Comparison { get; set; }

		#endregion
	}
}