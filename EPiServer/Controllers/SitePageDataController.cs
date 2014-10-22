using System;
using System.Globalization;
using EPiServer.Web.Mvc;
using HansKindberg.EPiServer.Modules.TestApplication.Models.Pages;
using HansKindberg.EPiServer.Modules.TestApplication.Models.ViewModels;

namespace HansKindberg.EPiServer.Modules.TestApplication.Controllers
{
	public abstract class SitePageDataController<T> : PageController<T> where T : SitePageData
	{
		#region Fields

		private const string _defaultViewPathFormat = "~/Views/{0}/Index.cshtml";
		private readonly IViewModelFactory _viewModelFactory;

		#endregion

		#region Constructors

		protected SitePageDataController(IViewModelFactory viewModelFactory)
		{
			if(viewModelFactory == null)
				throw new ArgumentNullException("viewModelFactory");

			this._viewModelFactory = viewModelFactory;
		}

		#endregion

		#region Properties

		protected internal virtual IViewModelFactory ViewModelFactory
		{
			get { return this._viewModelFactory; }
		}

		protected internal virtual string ViewPathFormat
		{
			get { return _defaultViewPathFormat; }
		}

		#endregion

		#region Methods

		protected internal virtual string GetViewPath(Type type)
		{
			if(type == null)
				throw new ArgumentNullException("type");

			return string.Format(CultureInfo.InvariantCulture, this.ViewPathFormat, type.Name);
		}

		#endregion
	}
}