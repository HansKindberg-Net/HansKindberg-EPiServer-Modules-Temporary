using System.Collections.Generic;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Filters
{
	public interface IPageTypeFilterSettings
	{
		#region Properties

		bool Exclude { get; }
		IEnumerable<int> Types { get; }

		#endregion
	}
}