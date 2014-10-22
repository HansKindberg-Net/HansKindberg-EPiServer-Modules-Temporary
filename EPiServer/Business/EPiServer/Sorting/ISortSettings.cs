using HansKindberg.EPiServer.Modules.TestApplication.Business.Sorting;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Sorting
{
	public interface ISortSettings
	{
		#region Properties

		SortDirection Direction { get; }
		SortOrder? Order { get; }

		#endregion
	}
}