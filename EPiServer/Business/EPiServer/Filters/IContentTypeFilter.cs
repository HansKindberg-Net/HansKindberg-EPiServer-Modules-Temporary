using System.Collections.Generic;
using EPiServer.Filters;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Filters
{
	public interface IContentTypeFilter : IContentFilter
	{
		#region Properties

		IEnumerable<int> ContentTypes { get; }
		bool Exclude { get; set; }

		#endregion
	}
}