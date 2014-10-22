namespace HansKindberg.EPiServer.Modules.TestApplication.Business.Collections
{
	public abstract class CollectionItem : ICollectionItem
	{
		#region Properties

		public virtual bool Selected { get; set; }
		public virtual object Value { get; set; }

		#endregion
	}

	public abstract class CollectionItem<T> : CollectionItem, ICollectionItem<T>
	{
		#region Properties

		public new virtual T Value
		{
			get { return (T) base.Value; }
			set { base.Value = value; }
		}

		#endregion
	}
}