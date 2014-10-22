using System;

namespace HansKindberg.EPiServer.Modules.TestApplication.Business.EPiServer.Collections
{
	public class ContentTreeSettings : ContentCollectionSettings, IContentTreeSettings
	{
		#region Fields

		private const bool _defaultExpandAll = true;
		private const bool _defaultIncludeRoot = true;
		private const int _defaultNumberOfLevels = int.MaxValue;
		private bool? _expandAll;
		private bool? _includeRoot;
		private int? _numberOfLevels;

		#endregion

		#region Properties

		protected internal virtual bool DefaultExpandAll
		{
			get { return _defaultExpandAll; }
		}

		protected internal virtual bool DefaultIncludeRoot
		{
			get { return _defaultIncludeRoot; }
		}

		protected internal virtual int DefaultNumberOfLevels
		{
			get { return _defaultNumberOfLevels; }
		}

		public virtual bool ExpandAll
		{
			get
			{
				if(this._expandAll == null)
					this._expandAll = this.DefaultExpandAll;

				return this._expandAll.Value;
			}
			set { this._expandAll = value; }
		}

		public virtual bool IncludeRoot
		{
			get
			{
				if(this._includeRoot == null)
					this._includeRoot = this.DefaultIncludeRoot;

				return this._includeRoot.Value;
			}
			set { this._includeRoot = value; }
		}

		public virtual int NumberOfLevels
		{
			get
			{
				if(this._numberOfLevels == null)
					this._numberOfLevels = this.DefaultNumberOfLevels;

				return this._numberOfLevels.Value;
			}
			set { this._numberOfLevels = value; }
		}

		#endregion

		#region Methods

		protected internal virtual void ValidateNumberOfLevels(int numberOfLevels)
		{
			if(numberOfLevels < 1)
				throw new ArgumentOutOfRangeException("numberOfLevels", numberOfLevels, "The number of levels can not be less than one.");
		}

		#endregion
	}
}