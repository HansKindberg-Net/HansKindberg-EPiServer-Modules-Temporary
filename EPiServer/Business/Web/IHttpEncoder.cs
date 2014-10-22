namespace HansKindberg.EPiServer.Modules.TestApplication.Business.Web
{
	public interface IHttpEncoder
	{
		#region Methods

		string HtmlEncode(string value);

		#endregion
	}
}