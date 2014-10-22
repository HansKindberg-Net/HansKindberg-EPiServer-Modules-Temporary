namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Collections
{
	public interface IContentTreeSettings : IContentCollectionSettings
	{
		#region Properties

		bool ExpandAll { get; }
		bool IncludeRoot { get; }
		int NumberOfLevels { get; }

		#endregion
	}
}