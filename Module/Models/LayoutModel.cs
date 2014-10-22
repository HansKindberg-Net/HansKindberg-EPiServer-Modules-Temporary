using System;
using System.Globalization;
using HansKindberg.EPiServer.Modules.Globalization;

namespace HansKindberg.EPiServer.Modules.ModuleTemplate.Models
{
	public class LayoutModel : ILayoutModel
	{
		#region Fields

		private readonly ICultureContext _cultureContext;
		private string _heading;
		private string _title;
		private CultureInfo _uiCulture;

		#endregion

		#region Constructors

		public LayoutModel(ICultureContext cultureContext)
		{
			if(cultureContext == null)
				throw new ArgumentNullException("cultureContext");

			this._cultureContext = cultureContext;
		}

		#endregion

		#region Properties

		protected internal virtual ICultureContext CultureContext
		{
			get { return this._cultureContext; }
		}

		public virtual string Heading
		{
			get { return this._heading ?? (this._heading = string.Empty); }
			set { this._heading = value; }
		}

		public virtual string Title
		{
			get { return this._title ?? (this._title = string.Empty); }
			set { this._title = value; }
		}

		public virtual CultureInfo UiCulture
		{
			get { return this._uiCulture ?? (this._uiCulture = this.CultureContext.UiCulture ?? CultureInfo.InvariantCulture); }
		}

		#endregion
	}
}