using System.Web.Mvc;
using HansKindberg.EPiServer.Modules.TestApplication.Models.Pages;
using HansKindberg.EPiServer.Modules.TestApplication.Models.ViewModels;

namespace HansKindberg.EPiServer.Modules.TestApplication.Controllers
{
	public class StartPageController : SitePageDataController<StartPage>
	{
		#region Constructors

		public StartPageController(IViewModelFactory viewModelFactory) : base(viewModelFactory) {}

		#endregion

		#region Methods

		public virtual ActionResult Index()
		{
			return this.View(this.ViewModelFactory.CreateViewModel<StartPageModel>());
		}

		#endregion
	}
}