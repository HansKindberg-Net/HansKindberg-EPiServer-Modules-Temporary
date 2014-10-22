namespace HansKindberg.EPiServer.Modules.TestApplication.Business.Pagination
{
	public interface IPaginationValidator
	{
		#region Methods

		void ValidatePageIndexKey(string pageIndexKey);

		#endregion
	}
}