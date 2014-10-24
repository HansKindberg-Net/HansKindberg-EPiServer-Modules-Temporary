using System.Collections.Specialized;
using System.Web;
using HansKindberg.Collections.Specialized;

namespace HansKindberg.Web.Collections.Specialized
{
	public class NameValueCollectionParser : INameValueCollectionParser
	{
		#region Methods

		public virtual NameValueCollection Parse(string value)
		{
			return HttpUtility.ParseQueryString(value);
		}

		#endregion
	}
}