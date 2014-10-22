namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Web
{
	public interface IUrlSegmentFactory
	{
		#region Methods

		string Create(string segment);

		#endregion
	}
}