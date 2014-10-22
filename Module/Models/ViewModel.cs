using System;

namespace HansKindberg.EPiServer.Modules.ModuleTemplate.Models
{
	public abstract class ViewModel
	{
		#region Fields

		private readonly ILayoutModel _layout;

		#endregion

		#region Constructors

		protected ViewModel(ILayoutModel layout)
		{
			if(layout == null)
				throw new ArgumentNullException("layout");

			this._layout = layout;
		}

		#endregion

		#region Properties

		public virtual ILayoutModel Layout
		{
			get { return this._layout; }
		}

		#endregion
	}
}