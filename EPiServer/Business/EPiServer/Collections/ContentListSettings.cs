namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Collections
{
	public class ContentListSettings : ContentCollectionSettings, IContentListSettings
	{
		#region Fields

		private const bool _defaultRecursive = false;
		private bool? _recursive;

		#endregion

		#region Properties

		protected internal virtual bool DefaultRecursive
		{
			get { return _defaultRecursive; }
		}

		public virtual bool Recursive
		{
			get
			{
				if(this._recursive == null)
					this._recursive = this.DefaultRecursive;

				return this._recursive.Value;
			}
			set { this._recursive = value; }
		}

		#endregion
	}
}