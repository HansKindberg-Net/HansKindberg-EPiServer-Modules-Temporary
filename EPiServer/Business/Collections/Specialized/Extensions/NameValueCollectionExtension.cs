using System;
using System.Collections.Specialized;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.Collections.Specialized.Extensions
{
	public static class NameValueCollectionExtension
	{
		#region Methods

		public static bool TryGetValueAndRemove(this NameValueCollection nameValueCollection, string key, out string value)
		{
			if(nameValueCollection == null)
				throw new ArgumentNullException("nameValueCollection");

			value = nameValueCollection[key];

			if(value != null)
				nameValueCollection.Remove(key);

			if(string.IsNullOrEmpty(value))
			{
				value = null;
				return false;
			}

			return true;
		}

		#endregion
	}
}