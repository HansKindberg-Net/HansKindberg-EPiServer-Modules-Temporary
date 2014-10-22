using System;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.Pagination
{
	public class PaginationValidator : IPaginationValidator
	{
		#region Methods

		public virtual void ValidatePageIndexKey(string pageIndexKey)
		{
			if(pageIndexKey == null)
				throw new ArgumentNullException("pageIndexKey");

			if(pageIndexKey.Length == 0)
				throw new ArgumentException("The page-index-key can not be empty.", "pageIndexKey");
		}

		#endregion
	}
}