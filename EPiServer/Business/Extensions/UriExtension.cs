using System;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.Extensions
{
	public static class UriExtension
	{
		#region Methods

		public static string PathAndQueryAndFragment(this Uri uri)
		{
			if(uri == null)
				throw new ArgumentNullException("uri");

			return uri.PathAndQuery + uri.Fragment;
		}

		#endregion
	}
}