using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer.Framework.Localization;
using EPiServer.Framework.Web.Resources;
using EPiServer.PlugIn;
using EPiServer.ServiceLocation;
using EPiServer.Shell.Modules;
using HansKindberg.EPiServer.Modules.ModuleTemplate.Models;
using HansKindberg.EPiServer.Shell;
using HansKindberg.EPiServer.Shell.Modules;
using HansKindberg.EPiServer.Shell.Modules.Web.Mvc.Controllers;
using HansKindberg.EPiServer.Shell.Modules.Web.Mvc.Models;

namespace HansKindberg.EPiServer.Modules.ModuleTemplate.Controllers
{
	[GuiPlugIn(Area = PlugInArea.AdminMenu, DisplayName = "ModuleTemplate", LanguagePath = _localizationPath, UrlFromModuleFolder = "Template")]
	public class TemplateController : Controller<TemplateViewModel>
	{
		#region Fields

		private const string _localizationPath = LocalizationPaths.Modules + "/template";

		#endregion

		#region Constructors

		public TemplateController(IPaths paths, IViewModelFactory viewModelFactory, LocalizationService localizationService) : base(paths, viewModelFactory, localizationService, _localizationPath) {}

		#endregion

		#region Methods

		public virtual ActionResult Index()
		{
			//var path = this.Paths.ToShellResource(string.Empty);

			//path = this.Paths.ToResource(typeof(string), string.Empty);

			//path = this.Paths.ToResource(this.GetType(), string.Empty);

			//path = path;

			var moduleTable = ServiceLocator.Current.GetInstance<ModuleTable>();
			moduleTable = moduleTable;

			IEnumerable<ShellModule> modules = moduleTable.GetModules().ToArray();
			modules = modules;

			foreach(var module in modules)
			{
				if(module.Name.Contains("Kindberg"))
				{
					var type = module.GetType().FullName;

					type = type;
				}
			}

			IEnumerable<IClientResourceProvider> clientResourceProviders = ServiceLocator.Current.GetAllInstances<IClientResourceProvider>().ToArray();

			clientResourceProviders = clientResourceProviders;

			IEnumerable<IClientResourceService> clientResourceServices = ServiceLocator.Current.GetAllInstances<IClientResourceService>().ToArray();

			clientResourceServices = clientResourceServices;

			var clientResourceService = ServiceLocator.Current.GetInstance<IClientResourceService>();
			clientResourceService = clientResourceService;

			var model = this.CreateViewModel();
			var viewPath = this.ViewPath;

			var view = this.View(viewPath, model);

			return view;
		}

		#endregion
	}
}