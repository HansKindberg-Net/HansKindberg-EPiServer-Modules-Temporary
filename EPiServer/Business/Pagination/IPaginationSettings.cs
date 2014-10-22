namespace HansKindberg.EPiServer.Modules.TestApplication.Business.Pagination
{
	public interface IPaginationSettings
	{
		#region Properties

		bool Enabled { get; }
		int? MaximumNumberOfDisplayedPages { get; }
		int? PageSize { get; }

		#endregion
	}
}