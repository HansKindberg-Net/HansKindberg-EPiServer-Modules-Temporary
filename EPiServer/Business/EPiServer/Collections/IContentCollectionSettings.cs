namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Collections
{
	public interface IContentCollectionSettings
	{
		#region Properties

		bool OnlyForVisitor { get; }
		bool OnlyVisibleInMenu { get; }

		#endregion
	}
}