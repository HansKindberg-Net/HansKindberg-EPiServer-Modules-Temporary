using System.Collections.Specialized;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.Collections.Specialized
{
	public interface INameValueCollectionParser
	{
		#region Methods

		NameValueCollection Parse(string value);

		#endregion
	}
}