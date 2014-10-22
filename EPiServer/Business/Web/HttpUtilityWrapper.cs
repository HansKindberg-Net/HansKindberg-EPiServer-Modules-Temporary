using System.Web;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.Web
{
	public class HttpUtilityWrapper : IHttpEncoder
	{
		#region Methods

		public virtual string HtmlEncode(string value)
		{
			return HttpUtility.HtmlEncode(value);
		}

		#endregion
	}
}