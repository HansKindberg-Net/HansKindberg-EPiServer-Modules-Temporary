using System;
using HansKindberg.EPiServer.Modules.TestApplication.Models.Pages;

namespace HansKindberg.EPiServer.Modules.TestApplication.Models.ViewModels
{
	public class PageViewModel<T> : IPageViewModel<T> where T : SitePageData
	{
		#region Fields

		private readonly T _currentPage;
		private readonly ILayoutModel _layout;

		#endregion

		#region Constructors

		public PageViewModel(T currentPage, ILayoutModel layout)
		{
			if(currentPage == null)
				throw new ArgumentNullException("currentPage");

			if(layout == null)
				throw new ArgumentNullException("layout");

			this._currentPage = currentPage;
			this._layout = layout;
		}

		#endregion

		#region Properties

		public virtual T CurrentPage
		{
			get { return this._currentPage; }
		}

		public virtual string Heading
		{
			get { return this.Layout.Heading; }
		}

		public virtual ILayoutModel Layout
		{
			get { return this._layout; }
		}

		#endregion
	}
}