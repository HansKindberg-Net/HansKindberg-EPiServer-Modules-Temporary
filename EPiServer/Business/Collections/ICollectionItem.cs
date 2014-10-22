namespace HansKindberg.EPiServer.Modules.TestApplication.Business.Collections
{
	public interface ICollectionItem
	{
		#region Properties

		bool Selected { get; }
		object Value { get; }

		#endregion
	}

	public interface ICollectionItem<out T> : ICollectionItem
	{
		#region Properties

		new T Value { get; }

		#endregion
	}
}