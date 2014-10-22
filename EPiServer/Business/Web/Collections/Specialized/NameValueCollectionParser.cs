using System.Collections.Specialized;
using System.Web;
using HansKindberg.EPiServer.Modules.TestApplication.Business.Collections.Specialized;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.Web.Collections.Specialized
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