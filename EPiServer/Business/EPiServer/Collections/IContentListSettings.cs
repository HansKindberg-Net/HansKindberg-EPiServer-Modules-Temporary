namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Collections
{
	public interface IContentListSettings : IContentCollectionSettings
	{
		#region Properties

		bool Recursive { get; }

		#endregion
	}
}