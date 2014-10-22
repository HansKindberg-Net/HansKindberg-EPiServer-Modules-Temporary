using System;
using System.Globalization;
using System.Web;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.Web.Pagination
{
	public class PaginationValidator : HansKindberg.EPiServer.Modules.TestApplication.Business.Pagination.PaginationValidator
	{
		#region Methods

		public override void ValidatePageIndexKey(string pageIndexKey)
		{
			base.ValidatePageIndexKey(pageIndexKey);

			if(pageIndexKey != HttpUtility.UrlEncode(pageIndexKey))
				throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "The value \"{0}\" is not a valid page-index-key.", pageIndexKey), "pageIndexKey");
		}

		#endregion
	}
}