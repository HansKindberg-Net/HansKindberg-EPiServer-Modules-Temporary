using System;
using System.Globalization;
using EPiServer.Framework.Localization;
using HansKindberg.EPiServer.Shell.Modules.Web.Mvc.Models;

namespace HansKindberg.EPiServer.Shell.Modules.Web.Mvc.Controllers
{
	public abstract class Controller<TViewModel> : System.Web.Mvc.Controller where TViewModel : ILayoutViewModel
	{
		#region Fields

		private const string _defaultViewPathFormat = "Views/{0}/Index.cshtml";
		private readonly string _localizationPath;
		private readonly LocalizationService _localizationService;
		private readonly IPaths _paths;
		private readonly IViewModelFactory _viewModelFactory;
		private string _viewName;

		#endregion

		#region Constructors

		protected Controller(IPaths paths, IViewModelFactory viewModelFactory, LocalizationService localizationService, string localizationPath)
		{
			if(paths == null)
				throw new ArgumentNullException("paths");

			if(viewModelFactory == null)
				throw new ArgumentNullException("viewModelFactory");

			if(localizationService == null)
				throw new ArgumentNullException("localizationService");

			this._localizationPath = localizationPath;
			this._localizationService = localizationService;
			this._paths = paths;
			this._viewModelFactory = viewModelFactory;
		}

		#endregion

		#region Properties

		protected internal virtual string LocalizationPath
		{
			get { return this._localizationPath; }
		}

		protected internal virtual LocalizationService LocalizationService
		{
			get { return this._localizationService; }
		}

		protected internal virtual IPaths Paths
		{
			get { return this._paths; }
		}

		protected internal virtual IViewModelFactory ViewModelFactory
		{
			get { return this._viewModelFactory; }
		}

		protected internal virtual string ViewName
		{
			get
			{
				// ReSharper disable ConvertIfStatementToNullCoalescingExpression

				if(this._viewName == null)
					this._viewName = this.GetType().Name.Replace("Controller", string.Empty);

				// ReSharper restore ConvertIfStatementToNullCoalescingExpression

				return this._viewName;
			}
		}

		protected internal virtual string ViewPath
		{
			get { return this.Paths.ToResource(this.GetType(), string.Format(CultureInfo.InvariantCulture, this.ViewPathFormat, this.ViewName)); }
		}

		protected internal virtual string ViewPathFormat
		{
			get { return _defaultViewPathFormat; }
		}

		#endregion

		#region Methods

		protected internal virtual TViewModel CreateViewModel()
		{
			var viewModel = this.ViewModelFactory.Create<TViewModel>();

			viewModel.Layout.LocalizationPath = this.LocalizationPath;
			viewModel.Layout.TypeInModuleAssembly = this.GetType();

			return viewModel;
		}

		#endregion
	}
}