using System;
using EPiServer.Framework.Localization;

namespace HansKindberg.EPiServer.Shell.Modules.Web.Mvc.Models
{
	public abstract class LayoutViewModel : ILayoutViewModel
	{
		#region Fields

		private readonly ILayoutModel _layout;
		private readonly LocalizationService _localizationService;

		#endregion

		#region Constructors

		protected LayoutViewModel(ILayoutModel layout, LocalizationService localizationService)
		{
			if(layout == null)
				throw new ArgumentNullException("layout");

			if(localizationService == null)
				throw new ArgumentNullException("localizationService");

			this._layout = layout;
			this._localizationService = localizationService;
		}

		#endregion

		#region Properties

		public virtual string Description
		{
			get { return this.Layout.Description; }
		}

		public virtual ILayoutModel Layout
		{
			get { return this._layout; }
		}

		protected internal virtual LocalizationService LocalizationService
		{
			get { return this._localizationService; }
		}

		public virtual string Name
		{
			get { return this.Layout.Name; }
		}

		#endregion

		#region Methods

		public virtual string GetResourcePath(string moduleRelativeResourcePath)
		{
			return this.Layout.GetResourcePath(moduleRelativeResourcePath);
		}

		public virtual string GetResourcePath(string moduleName, string moduleRelativeResourcePath)
		{
			return this.Layout.GetResourcePath(moduleName, moduleRelativeResourcePath);
		}

		#endregion
	}
}