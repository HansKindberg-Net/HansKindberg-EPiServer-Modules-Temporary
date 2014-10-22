namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Collections
{
	public abstract class ContentCollectionSettings : IContentCollectionSettings
	{
		#region Fields

		private const bool _defaultOnlyForVisitor = true;
		private const bool _defaultOnlyVisibleInMenu = false;
		private bool? _onlyForVisitor;
		private bool? _onlyVisibleInMenu;

		#endregion

		#region Properties

		protected internal virtual bool DefaultOnlyForVisitor
		{
			get { return _defaultOnlyForVisitor; }
		}

		protected internal virtual bool DefaultOnlyVisibleInMenu
		{
			get { return _defaultOnlyVisibleInMenu; }
		}

		public virtual bool OnlyForVisitor
		{
			get
			{
				if(this._onlyForVisitor == null)
					this._onlyForVisitor = this.DefaultOnlyForVisitor;

				return this._onlyForVisitor.Value;
			}
			set { this._onlyForVisitor = value; }
		}

		public virtual bool OnlyVisibleInMenu
		{
			get
			{
				if(this._onlyVisibleInMenu == null)
					this._onlyVisibleInMenu = this.DefaultOnlyVisibleInMenu;

				return this._onlyVisibleInMenu.Value;
			}
			set { this._onlyVisibleInMenu = value; }
		}

		#endregion
	}
}