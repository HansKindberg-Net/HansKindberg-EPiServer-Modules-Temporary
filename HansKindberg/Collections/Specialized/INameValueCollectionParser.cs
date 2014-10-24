using System.Collections.Specialized;

namespace HansKindberg.Collections.Specialized
{
	public interface INameValueCollectionParser
	{
		#region Methods

		NameValueCollection Parse(string value);

		#endregion
	}
}