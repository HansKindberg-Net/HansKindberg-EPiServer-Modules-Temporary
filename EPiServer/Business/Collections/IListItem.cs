namespace HansKindberg.EPiServer.Modules.TestApplication.Business.Collections
{
	public interface IListItem : ICollectionItem
	{
		#region Properties

		bool First { get; }
		int Index { get; }
		bool Last { get; }

		#endregion
	}

	public interface IListItem<out T> : IListItem, ICollectionItem<T> {}
}